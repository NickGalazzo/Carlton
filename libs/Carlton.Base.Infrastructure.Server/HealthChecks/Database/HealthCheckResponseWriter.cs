using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Server.HealthChecks.Database
{
    public class HealthCheckResponseWriter
    {
        private static Task WriteResponse(HttpContext httpContext, HealthReport result)
        {

            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
