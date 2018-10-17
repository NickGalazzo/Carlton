using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Middleware
{
    public class CarltonMetadataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _path;

        public CarltonMetadataMiddleware(RequestDelegate next, string path)
        {
            _next = next;
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == _path)
            {
                var applicationName = "Name";
                var version = Assembly.GetEntryAssembly()
                                             .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                             .InformationalVersion;

                var framework = Assembly.GetEntryAssembly()?
                                        .GetCustomAttribute<TargetFrameworkAttribute>()?
                                        .FrameworkName;
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
   

                var hostname = context.Request.Host.Value;

                await context.Response.WriteAsync(
                    $"Name: {applicationName}" +
                    $"{Environment.NewLine}" +
                    $"Version: {version}" +
                    $"{Environment.NewLine}" +
                    $"HostName: {hostname}" +
                    $"{Environment.NewLine}" +
                    $"Dotnet Version: {framework}" +
                    $"{Environment.NewLine}" +
                    $"Enviornment: {environment}"
                    );
            }
            else
            {
                await _next(context);
            }
        }
    }
}

