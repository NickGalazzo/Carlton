using Carlton.Infrastructure.Middleware;
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
            return builder.UseMiddleware<CarltonExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCarltonApiExceptionResponseMessage(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CarltonApiExceptionResponseMiddleware>();
        }

        public static IApplicationBuilder UseCarltonCorelationId(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CarltonCorrelationIdMiddleware>();
        }

        public static IApplicationBuilder UseCarltonCorelationId(this IApplicationBuilder app, string header)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CarltonCorrelationIdMiddleware>(new CorrelationIdOptions
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

            return app.UseMiddleware<CarltonCorrelationIdMiddleware>(options);
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

        public static IApplicationBuilder UseCalrtonMetadata(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<CarltonMetadataMiddleware>(path);
        }
    }
}
