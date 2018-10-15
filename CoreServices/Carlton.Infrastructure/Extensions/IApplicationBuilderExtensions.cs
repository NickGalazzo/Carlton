using Carlton.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace Carlton.Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCarltonExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CarltonExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCarltonHealthChecking(this IApplicationBuilder builder)
        {
            return builder.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = (httpContext, result) =>
                {
                    httpContext.Response.ContentType = "application/json";
                    return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));
                },
            });
        }
    }
}
