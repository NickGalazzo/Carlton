using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Server.Middleware
{
    public class ServerInfoMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _path;

        public ServerInfoMiddleware(RequestDelegate next, string path)
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

                await context.Response.WriteAsync(JsonConvert.SerializeObject
                    (new
                        {
                            Name = applicationName,
                            Version = version,
                            HostName = hostname,
                            DotnetVersion = framework,
                            Enviornment = environment
                        })).ConfigureAwait(false);
            }
            else
            {
                await _next(context).ConfigureAwait(false);
            }
        }
    }
}

