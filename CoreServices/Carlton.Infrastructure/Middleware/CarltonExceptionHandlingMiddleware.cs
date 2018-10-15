using Carlton.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sentry;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Middleware
{
    public class CarltonExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CarltonExceptionHandlingMiddleware(RequestDelegate next, ILogger<CarltonExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
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
                _logger.LogError(ex, $"Something went wrong");

                //Log the error to sentry
                SentrySdk.CaptureException(ex);

                //Write output
                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "Internal Server Error from the custom middleware."
                }.ToString());
            }
        }
    }
}
