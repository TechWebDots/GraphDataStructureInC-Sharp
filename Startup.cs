using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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
                      WeightedGraph<int> weightedGenericGraph = WeightedGraph<int>.BuidGraph();
                      await context.Response.WriteAsync("================================================\n");
                      await context.Response.WriteAsync("Generic Weighted Bi-Directional Graph\n");
                      await context.Response.WriteAsync("Adjacency List Implementation\n");
                      await context.Response.WriteAsync("================================================\n");
                      await context.Response.WriteAsync(WeightedGraph<int>.PrintGraph(weightedGenericGraph));
                      await context.Response.WriteAsync("\n================================================\n");
                      await context.Response.WriteAsync("Minimum Spanning Tree Prim's Algorithm\n");
                      await context.Response.WriteAsync("================================================\n");
                      List<WeightedEdge<int>> mstKruskal = weightedGenericGraph.MinimumSpanningTreePrim();
                      mstKruskal.ForEach(e => context.Response.WriteAsync(e.ToString() + "\n"));
                      #endregion

                      await context.Response.WriteAsync("");
                  });
              });
        }
    }
}
