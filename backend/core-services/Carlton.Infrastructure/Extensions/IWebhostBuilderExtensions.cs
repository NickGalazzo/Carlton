using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Carlton.Infrastructure.Extensions
{
    public static class IWebHostBuilderExtensions
    {
        public static IWebHostBuilder ConfigureCarltonLogging(this IWebHostBuilder builder)
        {
            return builder.ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddSentry();
                logging.AddFile(o => o.RootPath = AppContext.BaseDirectory);
            });
        }
    }
}
