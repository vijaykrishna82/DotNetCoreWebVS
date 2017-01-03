using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;

namespace NetCoreVSWeb
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; set; }


        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddDirectoryBrowser();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            loggerFactory.AddConsole();
            //app.UseDirectoryBrowser();
            //app.UseFileServer();
            app.UseStaticFiles();


            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet("route", x => x.Response.WriteAsync("Hello from Routing"));
            routeBuilder.MapGet("route2", x => x.Response.WriteAsync("Hello from Routing2"));
            routeBuilder.MapGet("route/3", x => x.Response.WriteAsync("Hello from Routing/3"));
            routeBuilder.MapGet("post/{postNumber:int}", x => x.Response.WriteAsync($"Hello from post/{x.GetRouteValue("postNumber")}"));
            routeBuilder.MapGet("post/{postNumber}", x => x.Response.WriteAsync($"Hello from post string/{x.GetRouteValue("postNumber")}"));

            var router = routeBuilder.Build();

            app.UseRouter(router);

            app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync($"Hello Vijay! {env.EnvironmentName} {Configuration["message"]}" +
                $" { SampleLibrary.Class1.Greeting()}");
            });


        }
    }
}
