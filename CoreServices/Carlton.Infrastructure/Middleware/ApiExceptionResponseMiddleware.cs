using Carlton.Infrastructure.ApiResults;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Middleware
{
    public class ApiExceptionResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionResponseMiddleware(RequestDelegate next)
        {
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
                //All exceptions that make it to this point 
                //are unhandled exceptions

                //Write output
                await httpContext.Response.WriteAsync(
                    JsonConvert.SerializeObject(
                        new ApiResult((int)HttpStatusCode.InternalServerError, ex.Message, null)
                   ));
            }
        }
    }
}

