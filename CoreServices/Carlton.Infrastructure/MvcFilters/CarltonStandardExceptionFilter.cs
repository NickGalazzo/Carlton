using Carlton.Infrastructure.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Infrastructure.MvcFilters
{
    public class CarltonStandardExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CarltonStandardExceptionFilter> _logger;

        public CarltonStandardExceptionFilter(ILogger<CarltonStandardExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch(exception)
            {
                case ValidationException e:
                    context.Result = new JsonResult(ApiResponse.CarltonApiResponse.CreateForbiddenResponse(e.Errors));
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case HttpConflictException e:
                    context.Result = new JsonResult(ApiResponse.CarltonApiResponse.CreateConflictResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case HttpResourceNotFoundException e:
                    context.Result = new JsonResult(ApiResponse.CarltonApiResponse.CreateNotFoundResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case UnauthorizedAccessException e:
                    context.Result = new JsonResult(ApiResponse.CarltonApiResponse.CreateUnauthorizedResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case CarltonRemoteServerException e:
                    context.Result = new JsonResult(ApiResponse.CarltonApiResponse.CreateServiceUnavailableResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                default:
                    throw new BaseCarltonException("Unhandled exception", exception);
            }
        }
    }
}
