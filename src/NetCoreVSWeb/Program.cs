using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace NetCoreVSWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseUrls("http://localhost:8081")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
            
             
           var builtHost = host     .Build();
           

            builtHost.Run();
        }
    }
}
