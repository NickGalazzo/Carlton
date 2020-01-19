using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Server.Middleware
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
            catch (Exception)
            {
                //All exceptions that make it to this point 
                //are unhandled exceptions

                //Write output
                await httpContext.Response.WriteAsync(
                    JsonConvert.SerializeObject(
                        ApiResponse.StandardApiResponse.CreateInternalServerErrorResponse()
                   ));
            }
        }
    }
}

