using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GraphDataStructureInC_Sharp
{    
    class BasicGraph
    {
        HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        #region This class represents a Directed Graph Implementation using LinkedList 
        //private variables
        private int totalVertices; // No. of vertices
        private LinkedList<int>[] linkedListArray;

        // Constructor
        public BasicGraph(int n)
        {
            totalVertices = n;
            linkedListArray = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
                linkedListArray[i] = new LinkedList<int>();
        }

        // Function to add an edge into the graph using adjacent vertex
        public void addEdge(int vertex, int adVertex)
        {
            linkedListArray[vertex].AddLast(adVertex);
        }

        #region bi-directional graph
        /// The method takes two nodes for which to add edge in bi-directional graph.        
        //public void AddEdge(int u, int v, bool blnBiDir = true)
        //{
        //    if (linkedListArray[u] == null)
        //    {
        //        linkedListArray[u] = new LinkedList<int>();
        //        linkedListArray[u].AddFirst(v);
        //    }
        //    else
        //    {
        //        var last = linkedListArray[u].Last;
        //        linkedListArray[u].AddAfter(last, v);
        //    }

        //    if (blnBiDir)
        //    {
        //        if (linkedListArray[v] == null)
        //        {
        //            linkedListArray[v] = new LinkedList<int>();
        //            linkedListArray[v].AddFirst(u);
        //        }
        //        else
        //        {
        //            var last = linkedListArray[v].Last;
        //            linkedListArray[v].AddAfter(last, u);
        //        }
        //    }
        //}

        // prints BFS traversal from a given source s
        #endregion

        public void PrintAdjanceyList()
        {
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("Graph Representation\n");
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("The Graph Adjacency List Representation:\n");
            _httpContext.Response.WriteAsync("------------------------------------------------\n");
            StringBuilder nodeString = new StringBuilder();
            //Taversing over each of the vertices - Printing the vertices
            for (int i = 0; i < linkedListArray.Length; i++)
            {                
                nodeString.Append("[Node Value: " + i + " with Neighbors");
                foreach (var item in linkedListArray[i])
                {
                    nodeString.Append(" -> " + item);
                }
                nodeString.Append(" ]\n"); 
            }
            _httpContext.Response.WriteAsync(nodeString.ToString());
        }

        public void CreateAdjanceyMatrix(BasicGraph graph)
        {
            
            int?[,] adjanceyMatrix = new int?[graph.totalVertices, graph.totalVertices];

            for (int parentVertex = 0; parentVertex < graph.totalVertices; parentVertex++)
            {
                var parentNode = linkedListArray[parentVertex];

                for (int childNode = 0; childNode < graph.totalVertices; childNode++)
                {  
                    if (parentVertex != childNode)
                    {
                        var arc = parentNode.Find(childNode);

                        if (arc != null)
                        {
                            adjanceyMatrix[parentVertex, childNode] = 1;
                        }
                    }                    
                }
            }

            PrintAdjanceyMatrix(adjanceyMatrix, graph.totalVertices);
        }

        public void PrintAdjanceyMatrix(int?[,] adjanceyMatrix, int Count)
        {
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("The Graph Adjacency Matrix Representation:\n");
            _httpContext.Response.WriteAsync("------------------------------------------------\n");
            _httpContext.Response.WriteAsync("Nodes  ");
            for (int i = 0; i < Count; i++)
            {
                _httpContext.Response.WriteAsync(string.Format("{0}  ", i));
            }

            _httpContext.Response.WriteAsync("\n");

            for (int i = 0; i < Count; i++)
            {
                _httpContext.Response.WriteAsync(string.Format("{0} | [ ", i));

                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                    {
                        _httpContext.Response.WriteAsync(" x ");
                    }
                    else if (adjanceyMatrix[i, j] == null)
                    {
                        _httpContext.Response.WriteAsync(" . ");
                    }
                    else
                    {
                        _httpContext.Response.WriteAsync(string.Format(" {0} ", adjanceyMatrix[i, j]));
                    }

                }
                _httpContext.Response.WriteAsync(" ]\r\n");
            }
            _httpContext.Response.WriteAsync("\r\n");
            _httpContext.Response.WriteAsync("================================================\n");
        }

        #region Search & Print In Graph
        //Function to check if there is any path exists between two nodes
        bool isReachable(int source, int destination)
        {
            // LinkedList<int> temp = new LinkedList<int>();

            // Mark all the vertices as not visited(By default set
            // as false)
            bool[] visited = new bool[totalVertices];

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as visited and enqueue it
            visited[source] = true;
            queue.AddLast(source);

            // 'i' will be used to get all adjacent vertices of a vertex
            IEnumerator i;
            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                source = queue.First.Value;
                queue.RemoveFirst();
                int n;
                i = linkedListArray[source].GetEnumerator();

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
                while (i.MoveNext())
                {
                    n = (int)i.Current;

                    // If this adjacent node is the destination node, then return true
                    if (n == destination)
                        return true;

                    // Else, continue to do BFS
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.AddLast(n);
                    }
                }
            }

            // If BFS is complete without visited d
            return false;
        }

        public void PathsSearch(BasicGraph graph, int source, int destination)
        {
            _httpContext.Response.WriteAsync("Try Path Search in the Graph\n");
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("Type Source Node from list:"+source+"\n");
            //int source = Convert.ToInt32(source);// arbitrary source 
            _httpContext.Response.WriteAsync("Type Destination Node from list:"+destination+"\n");
            //int destination = Convert.ToInt32(destination);

            if (graph.isReachable(source, destination))
            {
                _httpContext.Response.WriteAsync("There is a path from " + source + " to " + destination + " and following are the possible navigation(s)!\n");
                graph.printAllPaths(source, destination);
                //PathsSearch(graph);
            }
            else
            {
                _httpContext.Response.WriteAsync("There is no path from " + source + " to " + destination + ", Try Again!");
                //PathsSearch(graph);
            }
        }

        // Prints all paths from 'source' to 'destination' 
        public void printAllPaths(int source, int destination)
        {
            // isVisited[] keeps track of vertices in current path. 
            bool[] isVisited = new bool[totalVertices];
            List<int> pathList = new List<int>();

            // add source to path[] - localPathList<> stores actual vertices in the current path 
            pathList.Add(source);

            // Call recursive utility 
            printAllPathsUtil(source, destination, isVisited, pathList);
        }

        // A recursive function to print all paths from 'source' to 'destination'. 
        private void printAllPathsUtil(int source, int destination, bool[] isVisited, List<int> localPathList)
        {
            if (source.Equals(destination))
            {
                _httpContext.Response.WriteAsync(string.Join("->", localPathList));
                // if match found then no need 
                // to traverse more till depth 
                return;
            }

            // Mark the current node 
            isVisited[source] = true;

            // Recur for all the vertices adjacent to current vertex 
            foreach (int i in linkedListArray[source])
            {
                if (!isVisited[i])
                {
                    // store current node in path[] 
                    localPathList.Add(i);
                    printAllPathsUtil(i, destination, isVisited, localPathList);

                    // remove current node in path[] 
                    localPathList.Remove(i);
                }
            }

            // Mark the current node 
            isVisited[source] = false;
        }
        #endregion

        #endregion
    }

}

