using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;

namespace Carlton.Infrastructure.Configurations
{
    public class LoggingConfiguration
    {
        public static Action<WebHostBuilderContext, ILoggingBuilder> CarltonLoggingConfig = (hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     logging.AddSentry();
                     logging.AddFile(o => o.RootPath = AppContext.BaseDirectory);
                 };
    }
}
