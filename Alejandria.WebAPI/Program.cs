using Devon4Net.Application.WebAPI.Configuration.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Alejandria.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.InitializeDevonFw();
                });
    }
}
