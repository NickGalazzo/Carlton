using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sentry;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Server.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //Set the Status Code to 501
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
         
                //Set CORS headers
                httpContext.Response.Headers.Add("Access-Control-Expose-HEaders", "Application-Error");
                httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                //Log the error to all providers
                _logger.LogError(ex, $"An unhandled exception has occured");

                //Log the error to sentry
                SentrySdk.CaptureException(ex);

                //Rethrow exception so it can be handled for display by other Middleware 
                throw;
            }
        }
    }
}
