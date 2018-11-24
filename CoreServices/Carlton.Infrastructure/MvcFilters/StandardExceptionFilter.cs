﻿using Carlton.Infrastructure.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

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
                    context.Result = new JsonResult(ApiResponse.StandardApiResponse.CreateForbiddenResponse(e.Errors));
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case HttpConflictException e:
                    context.Result = new JsonResult(ApiResponse.StandardApiResponse.CreateConflictResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case HttpResourceNotFoundException e:
                    context.Result = new JsonResult(ApiResponse.StandardApiResponse.CreateNotFoundResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case UnauthorizedAccessException e:
                    context.Result = new JsonResult(ApiResponse.StandardApiResponse.CreateUnauthorizedResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                case RemoteServerException e:
                    context.Result = new JsonResult(ApiResponse.StandardApiResponse.CreateServiceUnavailableResponse());
                    _logger.LogWarning("Handled Exception", e);
                    break;
                default:
                    throw new CarltonBaseException("Unhandled exception", exception);
            }
        }
    }
}