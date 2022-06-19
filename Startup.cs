using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace GraphDataStructureInC_Sharp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor(); //or services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            _ = app.UseEndpoints(endpoints =>
              {
                  endpoints.MapGet("/", async context =>
                  {
                      #region Type 1 : Graph Using LinkedList
                      //BasicGraph graph = new BasicGraph(8);
                      //graph.addEdge(0, 2);
                      //graph.addEdge(1, 3);
                      //graph.addEdge(1, 4);
                      //graph.addEdge(2, 5);
                      //graph.addEdge(3, 5);
                      //graph.addEdge(4, 6);
                      //graph.addEdge(6, 7);
                      //graph.PrintAdjanceyList();
                      //graph.CreateAdjanceyMatrix(graph);
                      #endregion

                      #region Type 2 : Non-Zero Index Based Graph using Custom class
                      //StandardGraph myGraph = new StandardGraph();
                      //myGraph.AddNode(1);
                      //myGraph.AddNode(2);
                      //myGraph.AddNode(3);
                      //myGraph.AddNode(4);
                      //myGraph.AddNode(5);
                      //myGraph.AddNode(6);
                      //myGraph.AddNode(7);
                      //myGraph.AddNode(8);

                      //myGraph.AddEdge(1, 3);
                      //myGraph.AddEdge(3, 6);
                      //myGraph.AddEdge(2, 4);
                      //myGraph.AddEdge(4, 6);
                      //myGraph.AddEdge(2, 5);
                      //myGraph.AddEdge(5, 7);
                      //myGraph.AddEdge(7, 8);

                      //context.Response.WriteAsync(myGraph.ToString());
                      #endregion

                      #region Type 3 : Generic Graph<T> using Custom class
                      //Graph<int> genericGraph = Graph<int>.BuidGraph();
                      //await context.Response.WriteAsync("=============================================\n");
                      //await context.Response.WriteAsync("Generic Bi-Directional Graph\n");
                      //await context.Response.WriteAsync("Adjacency List Implementation\n");
                      //await context.Response.WriteAsync("=============================================\n");
                      //await context.Response.WriteAsync(Graph<int>.PrintGraph(genericGraph));
                      //#region Searching in Graph
                      //await context.Response.WriteAsync("\n\nType Source Node from list:");
                      //int source = 4;// arbitrary source 
                      //await context.Response.WriteAsync(source.ToString());
                      //await context.Response.WriteAsync("\nType Destination Node from list:");
                      //int destination = 1; // arbitrary destination 
                      //await context.Response.WriteAsync(destination.ToString());
                      //await context.Response.WriteAsync("\nSelect Search Type \n 0 for DFS \n 1 for BFS\n");
                      //SearchType searchType = SearchType.DFS;
                      //await context.Response.WriteAsync((int)searchType + "-" + searchType.ToString());
                      //await context.Response.WriteAsync("\nChecking the path if Reachable from Source node "
                      //    + source + " to Destination node " + destination);
                      //await context.Response.WriteAsync("\n" + searchType.ToString() + " : Path from "
                      //    + source.ToString() + " to " + destination.ToString() + " -> ");
                      //await context.Response.WriteAsync("\n--------------------------------");
                      //await context.Response.WriteAsync(genericGraph.Search(source, destination, genericGraph, searchType));
                      //#endregion
                      #endregion

                      #region Weighted Generic Graph<T> : Minimum Spanning Tree : Kruskal's Greedy Algorithm
                      //WeightedGraph<int> weightedGenericGraph = WeightedGraph<int>.BuidGraph();
                      //await context.Response.WriteAsync("================================================\n");
                      //await context.Response.WriteAsync("Generic Weighted Bi-Directional Graph\n");
                      //await context.Response.WriteAsync("Adjacency List Implementation\n");
                      //await context.Response.WriteAsync("================================================\n");
                      //await context.Response.WriteAsync(WeightedGraph<int>.PrintGraph(weightedGenericGraph));
                      //await context.Response.WriteAsync("\n================================================\n");
                      //await context.Response.WriteAsync("Minimum Spanning Tree Kruskal's Greedy Algorithm\n");
                      //await context.Response.WriteAsync("================================================\n");
                      //List<WeightedEdge<int>> mstKruskal = weightedGenericGraph.MinimumSpanningTreeKruskal();
                      //mstKruskal.ForEach(e => context.Response.WriteAsync(e.ToString()+"\n"));
                      #endregion

                      #region Weighted Generic Graph<T> : Minimum Spanning Tree : Prim's Algorithm
                      //WeightedGraph<int> weightedGenericGraph = WeightedGraph<int>.BuidGraph();
                      //await context.Response.WriteAsync("================================================\n");
                      //await context.Response.WriteAsync("Generic Weighted Bi-Directional Graph\n");
                      //await context.Response.WriteAsync("Adjacency List Implementation\n");
                      //await context.Response.WriteAsync("================================================\n");
                      //await context.Response.WriteAsync(WeightedGraph<int>.PrintGraph(weightedGenericGraph));
                      //await context.Response.WriteAsync("\n================================================\n");
                      //await context.Response.WriteAsync("Minimum Spanning Tree Prim's Algorithm\n");
                      //await context.Response.WriteAsync("================================================\n");
                      //List<WeightedEdge<int>> mstPrim = weightedGenericGraph.MinimumSpanningTreePrim();
                      //mstPrim.ForEach(e => context.Response.WriteAsync(e.ToString() + "\n"));
                      #endregion

                      #region Weighted Generic Graph<T> : Coloring : Voivodeship Map
                      //WeightedGraph<int> weightedGenericGraph = WeightedGraph<int>.BuidGraph();
                      //await context.Response.WriteAsync("================================================\n");
                      //await context.Response.WriteAsync("Generic Weighted Bi-Directional Graph\n");
                      //await context.Response.WriteAsync("Adjacency List Implementation\n");
                      //await context.Response.WriteAsync("================================================\n");
                      //await context.Response.WriteAsync(WeightedGraph<int>.PrintGraph(weightedGenericGraph));
                      //await context.Response.WriteAsync("\n================================================\n");
                      //await context.Response.WriteAsync("Coloring : Voivodeship Map\n");
                      //await context.Response.WriteAsync("================================================\n");

                      //int[] colors = weightedGenericGraph.Color();
                      //for (int i = 0; i < colors.Length; i++)
                      //{
                      //    await context.Response.WriteAsync($"Node " +
                      //        $"{weightedGenericGraph.Nodes[i].Value}: " +
                      //        $"{colors[i]} \n");
                      //}
                      #endregion

                      #region Weighted Generic Graph<T> : Shortest path - Dijkstra's Algorithm
                      #region Create New Graph with Nodes and Edges
                      WeightedGraph<int> graph = new WeightedGraph<int>(true, true);
                      WeightedGraphNode<int> n1 = graph.AddNode(1);
                      WeightedGraphNode<int> n2 = graph.AddNode(2);
                      WeightedGraphNode<int> n3 = graph.AddNode(3);
                      WeightedGraphNode<int> n4 = graph.AddNode(4);
                      WeightedGraphNode<int> n5 = graph.AddNode(5);
                      WeightedGraphNode<int> n6 = graph.AddNode(6);
                      WeightedGraphNode<int> n7 = graph.AddNode(7);
                      WeightedGraphNode<int> n8 = graph.AddNode(8);
                      graph.AddEdge(n1, n2, 9);
                      graph.AddEdge(n1, n3, 5);
                      graph.AddEdge(n2, n1, 3);
                      graph.AddEdge(n2, n4, 18);
                      graph.AddEdge(n3, n4, 12);
                      graph.AddEdge(n4, n8, 8);
                      graph.AddEdge(n4, n2, 2);
                      graph.AddEdge(n5, n4, 9);
                      graph.AddEdge(n5, n6, 2);
                      graph.AddEdge(n5, n8, 3);
                      graph.AddEdge(n5, n7, 5);
                      graph.AddEdge(n6, n7, 1);
                      graph.AddEdge(n7, n5, 4);
                      graph.AddEdge(n7, n8, 6);
                      graph.AddEdge(n8, n5, 3);
                      #endregion
                      await context.Response.WriteAsync("================================================\n");
                      await context.Response.WriteAsync("Generic Weighted Directed Graph\n");
                      await context.Response.WriteAsync("Adjacency List Implementation\n");
                      await context.Response.WriteAsync("================================================\n");
                      await context.Response.WriteAsync(WeightedGraph<int>.PrintGraph(graph));
                      await context.Response.WriteAsync("\n================================================\n");
                      await context.Response.WriteAsync("Dijkstra's Algorithm Shortest Path Node 1->7\n");
                      await context.Response.WriteAsync("================================================\n");

                      List<WeightedEdge<int>> path = graph.GetShortestPathDijkstra(graph.Nodes[0], graph.Nodes[6]);
                      path.ForEach(e => context.Response.WriteAsync(e.ToString() + "\n"));
                      #endregion

                      #region Weighted Generic Graph<T> : Shortest path - Dijkstra's Algorithm - Game Map
                      //string[] lines = new string[]
                      //{
                      //  "0011100000111110000011111",
                      //  "0011100000111110000011111",
                      //  "0011100000111110000011111",
                      //  "0000000000011100000011111",
                      //  "0000001110000000000011111",
                      //  "0001001110011100000011111",
                      //  "1111111111111110111111100",
                      //  "1111111111111110111111101",
                      //  "1111111111111110111111100",
                      //  "0000000000000000111111110",
                      //  "0000000000000000111111100",
                      //  "0001111111001100000001101",
                      //  "0001111111001100000001100",
                      //  "0001100000000000111111110",
                      //  "1111100000000000111111100",
                      //  "1111100011001100100010001",
                      //  "1111100011001100001000100"
                      //};
                      //bool[][] map = new bool[lines.Length][];
                      //for (int i = 0; i < lines.Length; i++)
                      //{
                      //    map[i] = lines[i]
                      //        .Select(c => int.Parse(c.ToString()) == 0)
                      //        .ToArray();
                      //}

                      //WeightedGraph<string> graph = new WeightedGraph<string>(false, true);
                      //for (int i = 0; i < map.Length; i++)
                      //{
                      //    for (int j = 0; j < map[i].Length; j++)
                      //    {
                      //        if (map[i][j])
                      //        {
                      //            WeightedGraphNode<string> from = graph.AddNode($"{i}-{j}");

                      //            if (i > 0 && map[i - 1][j])
                      //            {
                      //                WeightedGraphNode<string> to = graph.Nodes.Find(n => n.Value == $"{i - 1}-{j}");
                      //                graph.AddEdge(from, to, 1);
                      //            }

                      //            if (j > 0 && map[i][j - 1])
                      //            {
                      //                WeightedGraphNode<string> to = graph.Nodes.Find(n => n.Value == $"{i}-{j - 1}");
                      //                graph.AddEdge(from, to, 1);
                      //            }
                      //        }
                      //    }
                      //}
                      //WeightedGraphNode<string> source = graph.Nodes.Find(n => n.Value == "0-0");
                      //WeightedGraphNode<string> target = graph.Nodes.Find(n => n.Value == "16-24");
                      //List<WeightedEdge<string>> path = graph.GetShortestPathDijkstra(source, target);
                      //Console.OutputEncoding = Encoding.UTF8;
                      //for (int row = 0; row < map.Length; row++)
                      //{
                      //    for (int column = 0; column < map[row].Length; column++)
                      //    {
                      //        ConsoleColor color = map[row][column]
                      //            ? ConsoleColor.Green : ConsoleColor.Red;
                      //        if (path.Any(e => e.From.Value == $"{row}-{column}"
                      //            || e.To.Value == $"{row}-{column}"))
                      //        {
                      //            color = ConsoleColor.White;
                      //        }

                      //        Console.ForegroundColor = color;
                      //        Console.Write("\u25cf ");
                      //    }
                      //    Console.WriteLine();
                      //}
                      //Console.ForegroundColor = ConsoleColor.Gray;
                      #endregion

                      await context.Response.WriteAsync("");
                  });
              });
        }
    }
}
