using Carlton.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Carlton.Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCarltonExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CarltonExceptionHandlingMiddleware>();
        }
    }
}
