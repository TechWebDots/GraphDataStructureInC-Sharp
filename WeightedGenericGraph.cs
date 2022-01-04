using System.Collections.Generic;
using System.Text;

namespace GraphDataStructureInC_Sharp
{
    #region WeightedGraphNode: Create Node Structure
    public class WeightedGraphNode<T>
    {
        #region Properties - Index, Value, Neighbors, Weights         
        public int Index { get; set; }
        public T Value { get; set; }
        public List<WeightedGraphNode<T>> Neighbors { get; set; } = new List<WeightedGraphNode<T>>();
        public List<int> Weights { get; set; } = new List<int>();
        #endregion  
        #region Basic Operations-AddNeighbors, RemoveNeighbors, ToString
        public bool AddNeighbors(WeightedGraphNode<T> neighbor)
        {
            if (Neighbors.Contains(neighbor))
            {
                return false;
            }
            else
            {
                Neighbors.Add(neighbor);
                return true;
            }
        }
        //public bool RemoveNeighbors(WeightedGraphNode<T> neighbor)
        //{
        //    return Neighbors.Remove(neighbor);
        //}

        //public bool RemoveAllNeighbors()
        //{
        //    for (int i = Neighbors.Count; i >= 0; i--)
        //    {
        //        Neighbors.RemoveAt(i);
        //    }
        //    return true;
        //}
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[ Node Value - " + Value + " with Neighbors : ");
            for (int i = 0; i < Neighbors.Count; i++)
            {
                //WeightedEdge<T> edge = new WeightedEdge<T>()
                //{
                //    From = this,
                //    To = this.Neighbors[i],
                //    Weight = i < this.Weights.Count ? this.Weights[i] : 0
                //};
                nodeString.Append(Neighbors[i].Value + " ");// + edge.ToString()+ " ");                
            }
            nodeString.Append("]");
            return nodeString.ToString();
        }
        #endregion
    }
    #endregion

    #region WeightedEdge: Create Weighted Edge Structure
    public class WeightedEdge<T>
    {
        public WeightedGraphNode<T> From { get; set; }
        public WeightedGraphNode<T> To { get; set; }
        public int Weight { get; set; }
        // ComparatorTo for sorting edges based on their weight
        //public int CompareTo(WeightedEdge<T> compareEdge)
        //{
        //    return this.Weight - compareEdge.Weight;
        //}
        public override string ToString()
        {
            return $"WeightedEdge: {From.Value} -> {To.Value}, weight: { Weight}";
        }
    }
    #endregion

    #region WeightedGraph: Create Undirected, Weighted Structure, Build, Search and Get the path  
    public class WeightedGraph<T>
    {
        #region WeightedGraph: Internal Variable - list of nodes        
        List<WeightedGraphNode<T>> nodes = new List<WeightedGraphNode<T>>();
        private bool _isDirected = false;
        private bool _isWeighted = false;
        #endregion

        #region WeightedGraph: constructor
        public WeightedGraph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }
        #endregion        

        #region WeightedGraph: Readonly Properties - Count, Nodes        
        public int Count
        {
            get
            {
                return nodes.Count;
            }
        }
        public List<WeightedGraphNode<T>> Nodes
        {
            get
            {
                return nodes;
            }
        }
        #endregion

        #region WeightedGraph: Internal class subset
        public class Subset<T>
        {
            public WeightedGraphNode<T> Parent { get; set; }
            public int Rank { get; set; }

            public override string ToString()
            {
                return $"Subset with rank {Rank}, parent: {Parent.Value} (index: { Parent.Index})";
            }
        }
        #endregion

        #region WeightedGraph: Add Node/Edge, Find, Remove Node/Edge, ToString                 
        public WeightedGraphNode<T> AddNode(T value)
        {
            WeightedGraphNode<T> node = new WeightedGraphNode<T>() { Value = value };
            if (Find(node) !=null)
            {
                //duplicate value
                return null;
            }
            else
            {
                Nodes.Add(node);
                UpdateIndices();
                return node;
            }
        }        
        public bool AddEdge(WeightedGraphNode<T> from, WeightedGraphNode<T> to, int weight)
        {
            WeightedGraphNode<T> source = Find(from);
            WeightedGraphNode<T> destination = Find(to);
            if (source == null || destination == null)
            {
                return false;
            }   
            else if (source.Neighbors.Contains(destination))
            {
                return false;
            }
            else
            {
                //for direted graph only below 1st line is required  node1->node2
                from.AddNeighbors(to);
                if (_isWeighted)
                {
                    source.Weights.Add(weight);
                }
                //for undireted graph need below line as well
                if (!_isDirected)
                {
                    to.AddNeighbors(from);
                    if (_isWeighted)
                    {
                        to.Weights.Add(weight);
                    }
                }
                return true;
            }
        }
        public WeightedGraphNode<T> Find(WeightedGraphNode<T> weightedGraphNode)
        {
            foreach (WeightedGraphNode<T> node in nodes)
            {
                if (node.Value.Equals(weightedGraphNode.Value))
                {
                    return node;
                }
            }
            return null;
        }
        //public bool RemoveNode(WeightedGraphNode<T> value)
        //{
        //    WeightedGraphNode<T> removeNode= Find(value);
        //    if (removeNode==null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        nodes.Remove(removeNode);
        //        foreach (WeightedGraphNode<T> node in nodes)
        //        {
        //            node.RemoveNeighbors(removeNode);
        //            RemoveEdge(node,removeNode);
        //        }
        //        return true;
        //    }
        //}
        //public bool RemoveEdge(WeightedGraphNode<T> from, WeightedGraphNode<T> to)
        //{
        //    WeightedGraphNode<T> node1 = Find(from);
        //    WeightedGraphNode<T> node2 = Find(to);
        //    if (node1 == null || node2 == null)
        //    {
        //        return false;
        //    }
        //    else if (!node1.Neighbors.Contains(node2))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        //for direted graph only below 1st line is required  node1->node2
        //        int index = from.Neighbors.FindIndex(n => n == to);
        //        if (index >= 0)
        //        {
        //            from.Neighbors.RemoveAt(index);
        //            if (_isWeighted)
        //            {
        //                from.Weights.RemoveAt(index);
        //            }
        //        }
        //        //for undireted graph need below line as well
        //        index = to.Neighbors.FindIndex(n => n == from);
        //        if (index >= 0)
        //        {
        //            to.Neighbors.RemoveAt(index);
        //            if (_isWeighted)
        //            {
        //                to.Weights.RemoveAt(index);
        //            }
        //        }
        //        return true;
        //    }
        //}        
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();            
            for (int i = 0; i < Count; i++)
            {
                nodeString.Append(nodes[i].ToString());
                if (i<Count-1)
                {
                    nodeString.Append("\n");
                }
            }
            return nodeString.ToString();
        }
        #endregion

        #region WeightedGraph: Build, Print, Previous node setup 
        internal static WeightedGraph<int> BuidGraph()
        {            
            WeightedGraph<int> graph = new WeightedGraph<int>(false,true);
            WeightedGraphNode<int> n1 = graph.AddNode(1);
            WeightedGraphNode<int> n2 = graph.AddNode(2);
            WeightedGraphNode<int> n3 = graph.AddNode(3);
            WeightedGraphNode<int> n4 = graph.AddNode(4);
            WeightedGraphNode<int> n5 = graph.AddNode(5);
            WeightedGraphNode<int> n6 = graph.AddNode(6);
            WeightedGraphNode<int> n7 = graph.AddNode(7);
            WeightedGraphNode<int> n8 = graph.AddNode(8);

            graph.AddEdge(n1, n2, 3);
            graph.AddEdge(n1, n3, 5);
            graph.AddEdge(n2, n4, 4);
            graph.AddEdge(n3, n4, 12);
            graph.AddEdge(n4, n5, 9);
            graph.AddEdge(n4, n8, 8);
            graph.AddEdge(n5, n6, 4);
            graph.AddEdge(n5, n8, 1);
            graph.AddEdge(n5, n7, 5);
            graph.AddEdge(n6, n7, 6);
            graph.AddEdge(n7, n8, 20);
            return graph;
        }                
        internal static string PrintGraph(WeightedGraph<T> graph)
        {
            return graph.ToString();
        }  
        #endregion        

        #region WeightedGraph: GetEdges, GetRoot, Subset, Union, UpdateIndices 
        public List<WeightedEdge<T>> GetEdges()
        {
            List<WeightedEdge<T>> edges = new List<WeightedEdge<T>>();
            foreach (WeightedGraphNode<T> from in Nodes)
            {
                for (int i = 0; i < from.Neighbors.Count; i++)
                {
                    WeightedEdge<T> edge = new WeightedEdge<T>()
                    {
                        From = from,
                        To = from.Neighbors[i],
                        Weight = i < from.Weights.Count ? from.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
            }
            return edges;
        }
        //Increase the Index Value
        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
        }
        //public WeightedEdge<T> this[int from, int to]
        //{
        //    get
        //    {
        //        WeightedGraphNode<T> nodeFrom = Nodes[from];
        //        WeightedGraphNode<T> nodeTo = Nodes[to];
        //        int i = nodeFrom.Neighbors.IndexOf(nodeTo);
        //        if (i >= 0)
        //        {
        //            WeightedEdge<T> edge = new WeightedEdge<T>()
        //            {
        //                From = nodeFrom,
        //                To = nodeTo,
        //                Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
        //            };
        //            return edge;
        //        }

        //        return null;
        //    }
        //}        
        private WeightedGraphNode<T> GetRoot(Subset<T>[] subsets, WeightedGraphNode<T> node)
        {
            if (subsets[node.Index].Parent != node)
            {
                subsets[node.Index].Parent = GetRoot(
                    subsets,
                    subsets[node.Index].Parent);
            }

            return subsets[node.Index].Parent;
        }
        private void Union(Subset<T>[] subsets, WeightedGraphNode<T> from, WeightedGraphNode<T> to)
        {
            if (subsets[from.Index].Rank > subsets[to.Index].Rank)
            {
                subsets[to.Index].Parent = from;
            }
            else if (subsets[from.Index].Rank < subsets[to.Index].Rank)
            {
                subsets[from.Index].Parent = to;
            }
            else
            {
                subsets[to.Index].Parent = from;
                subsets[from.Index].Rank++;
            }
        }
        
        #endregion

        #region WeightedGraph: MinimumSpanningTreeKruskal 
        public List<WeightedEdge<T>> MinimumSpanningTreeKruskal()
        {
            List<WeightedEdge<T>> edges = GetEdges();
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            Queue<WeightedEdge<T>> queue = new Queue<WeightedEdge<T>>(edges);

            Subset<T>[] subsets = new Subset<T>[Nodes.Count];
            for (int i = 0; i < Nodes.Count; i++)
            {
                subsets[i] = new Subset<T>() { Parent = Nodes[i] };
            }

            List<WeightedEdge<T>> result = new List<WeightedEdge<T>>();
            while (result.Count < Nodes.Count - 1)
            {
                WeightedEdge<T> edge = queue.Dequeue();
                WeightedGraphNode<T> from = GetRoot(subsets, edge.From);
                WeightedGraphNode<T> to = GetRoot(subsets, edge.To);
                if (from != to)
                {
                    result.Add(edge);
                    Union(subsets, from, to);
                }
            }

            return result;
        }
        #endregion
    }
    #endregion

}
