using Carlton.Infrastructure.ApiResponse;
using Carlton.Infrastructure.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Web.Http.Results;

namespace Carlton.Infrastructure.MvcFilters
{
    public class StandardExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<StandardExceptionFilter> _logger;

        public StandardExceptionFilter(ILogger<StandardExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch(exception)
            {
                case ValidationException e:
                    context.Result = new ObjectResult(ApiResponse.StandardApiResponse.CreateForbiddenResponse(e.Errors));
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case HttpConflictException e:
                    context.Result = new ObjectResult(ApiResponse.StandardApiResponse.CreateConflictResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case HttpResourceNotFoundException e:
                    context.Result = new ObjectResult(ApiResponse.StandardApiResponse.CreateNotFoundResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case UnauthorizedAccessException e:
                    context.Result = new ObjectResult(ApiResponse.StandardApiResponse.CreateUnauthorizedResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case RemoteServerException e:
                    context.Result = new ObjectResult(ApiResponse.StandardApiResponse.CreateServiceUnavailableResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                default:
                    throw new CarltonBaseException("Unhandled exception", exception);
            }
        }
    }
}
