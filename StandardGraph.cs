using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace GraphDataStructureInC_Sharp
{
    public class GraphNode
    {
        private int _value;
        List<GraphNode> _neighbors;
        public GraphNode(int value)
        {
            this._value = value;
            _neighbors = new List<GraphNode>();
        }
        public int Value
        {
            get
            {
                return _value;
            }
        }
        public List<GraphNode> Neighbors
        {
            get
            {
                return _neighbors;
            }
        }
        public bool AddNeighbor(GraphNode neighbor)
        {
            if (_neighbors.Contains(neighbor))
            {
                return false;
            }
            else
            {
                _neighbors.Add(neighbor);
                return true;
            }
        }
        public bool RemoveNeighbor(GraphNode myGraphNode)
        {
            if (_neighbors.Contains(myGraphNode))
            {
                return _neighbors.Remove(myGraphNode);
            }
            return false;
        }
        public bool RemoveAllNeighbor()
        {
            foreach (GraphNode item in _neighbors)
            {
                _neighbors.Remove(item);
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[Node Value: " + Value + " with Neighbors");
            foreach (var item in _neighbors)
            {
                nodeString.Append(" -> " + item.Value);
            }
            nodeString.Append(" ]");
            return nodeString.ToString();
        }
    }
    public class StandardGraph
    {
        HttpContext _httpContext
            => new HttpContextAccessor().HttpContext;
        List<GraphNode> myGraphNodes = new List<GraphNode>();
        public StandardGraph()
        {

        }
        //Neighbor: Add, Find, Remove, Clear
        public int Count
        {
            get
            {
                return myGraphNodes.Count;
            }
        }
        public IList<GraphNode> GraphNodes
        {
            get
            {
                return myGraphNodes.AsReadOnly();
            }
        }
        public bool AddNode(int value)
        {
            if (Find(value) != null)
            {
                return false;
            }
            else
            {
                myGraphNodes.Add(new GraphNode(value));
                return true;
            }
        }
        public bool AddEdge(int n1, int n2)
        {
            GraphNode gn1 = Find(n1);
            GraphNode gn2 = Find(n2);
            if (gn1 == null && gn2 == null)
            {
                return false;
            }
            else if (gn1.Neighbors.Contains(gn2))
            {
                return false;
            }
            else
            {
                gn1.AddNeighbor(gn2);
                return true;
            }
        }
        GraphNode Find(int value)
        {
            foreach (GraphNode item in myGraphNodes)
            {
                if (item.Value.Equals(value))
                {
                    return item;
                }
            }
            return null;
        }
        public bool RemoveNode(int value)
        {
            GraphNode TBR = Find(value);
            if (TBR != null)
            {
                myGraphNodes.Remove(TBR);
                foreach (GraphNode item in myGraphNodes)
                {
                    item.RemoveNeighbor(TBR);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveEdge(int n1, int n2)
        {
            GraphNode gn1 = Find(n1);
            GraphNode gn2 = Find(n2);
            if (gn1 == null || gn2 == null)
            {
                return false;
            }
            else if (!gn1.Neighbors.Contains(gn2))
            {
                return false;
            }
            else
            {
                gn1.RemoveNeighbor(gn2);
                return true;
            }
        }
        public bool Clear()
        {
            foreach (GraphNode item in myGraphNodes)
            {
                item.RemoveAllNeighbor();
            }
            for (int i = Count - 1; i >= 0; i--)
            {
                myGraphNodes.RemoveAt(i);
            }
            return true;
        }
        public override string ToString()
        {
            _httpContext.Response.WriteAsync("========================================\n");
            _httpContext.Response.WriteAsync("New Graph Adjacency List Implementation:\n");
            _httpContext.Response.WriteAsync("----------[Non Zero Index Based]--------\n");
            _httpContext.Response.WriteAsync("========================================\n");
            StringBuilder nodeString = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                nodeString.Append(myGraphNodes[i].ToString());
                if (i < Count - 1)
                {
                    nodeString.Append("\n");
                }
            }
            return nodeString.ToString();
        }
    }
}
