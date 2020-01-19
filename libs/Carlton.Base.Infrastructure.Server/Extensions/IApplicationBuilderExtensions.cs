using Carlton.Infrastructure.Middleware;
using Carlton.Infrastructure.Server.Correlation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace Carlton.Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCarltonExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCarltonApiExceptionResponseMessage(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiExceptionResponseMiddleware>();
        }

        public static IApplicationBuilder UseCarltonCorelationId(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CorrelationIdMiddleware>();
        }

        public static IApplicationBuilder UseCarltonCorelationId(this IApplicationBuilder app, string header)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CorrelationIdMiddleware>(new CorrelationIdOptions
            {
                Header = header
            });
        }

        public static IApplicationBuilder UseCarltonCorelationId(this IApplicationBuilder app, CorrelationIdOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<CorrelationIdMiddleware>(options);
        }

        public static IApplicationBuilder UseCarltonHealthChecking(this IApplicationBuilder app)
        {
            return app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = (httpContext, result) =>
                {
                    httpContext.Response.ContentType = "application/json";
                    return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));
                },
            });
        }

        public static IApplicationBuilder UseCalrtonServerInfo(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<ServerInfoMiddleware>(path);
        }
    }
}
