using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    #region Graph Type 1
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

                    #region Graph Type 2
                    StandardGraph myGraph = new StandardGraph();
                    myGraph.AddNode(1);
                    myGraph.AddNode(2);
                    myGraph.AddNode(3);
                    myGraph.AddNode(4);
                    myGraph.AddNode(5);
                    myGraph.AddNode(6);
                    myGraph.AddNode(7);
                    myGraph.AddNode(8);

                    myGraph.AddEdge(1, 3);
                    myGraph.AddEdge(3, 6);
                    myGraph.AddEdge(2, 4);
                    myGraph.AddEdge(4, 6);
                    myGraph.AddEdge(2, 5);
                    myGraph.AddEdge(5, 7);
                    myGraph.AddEdge(7, 8);

                    context.Response.WriteAsync(myGraph.ToString());
                    #endregion
                    await context.Response.WriteAsync("");
                });
            });
        }
    }
}
