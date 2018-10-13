using Carlton.Infrastructure.Configurations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Calrton.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureLogging(LoggingConfiguration.CarltonLoggingConfig)
                   .UseStartup<Startup>();
    }
}
