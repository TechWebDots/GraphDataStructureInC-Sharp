using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace GraphDataStructureInC_Sharp
{    
    class BasicGraph
    {
        HttpContext _httpContext 
            => new HttpContextAccessor().HttpContext;
        #region private variables
        //This class represents a Directed Graph Implementation using LinkedList private variables
        private int totalVertices; // No. of vertices
        private LinkedList<int>[] linkedListArray;
        #endregion
        // Constructor
        public BasicGraph(int n)
        {
            totalVertices = n;
            linkedListArray = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
                linkedListArray[i] = new LinkedList<int>();
        }
        // Function to add an edge using adjacent vertex
        public void addEdge(int vertex, int adVertex)
        {
            linkedListArray[vertex].AddLast(adVertex);
        }        
        // Function to PrintAdjanceyList
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
        // Function to CreateAdjanceyMatrix
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
        // Function to PrintAdjanceyMatrix
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
            _httpContext.Response.WriteAsync("================================================\n");
        }        
    }
}

