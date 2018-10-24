using Carlton.Domain.Commands;
using Carlton.Domain.Exceptions;
using Carlton.Domain.Queries;
using Carlton.Domain.Repository;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class ExceptionInterceptor
    {
        private readonly ILogger<ExceptionInterceptor> _logger;

        public ExceptionInterceptor(ILogger<ExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var scope = GetScopeText(invocation.TargetType);

            using (_logger.BeginScope(scope))
                try
                {
                    _logger.LogInformation($"Entering Handler of type: {invocation.TargetType}");
                    invocation.Proceed();
                    _logger.LogInformation($"Exiting Handler of type: {invocation.TargetType}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in Repository of type: {requestType}");

                    switch (request)
                    {
                        case  c:
                            throw new CommandException(c, $"Error occured while executing command {requestType}", ex);
                        case IQuery q:
                            throw new QueryException(q, $"Error occured while executing query {requestType}", ex);
                        default:
                            throw new ArgumentException("Request is neither a command nor query; this should never happen");
                    }
                }
        }

        private string GetScopeText(Type type)
        {
            if(nameof(type) typename)


            switch(nameof(type) typeName)
            {
                case typeName.Contains(""):
                    return "Command";
                case IQueryHandler q:
                    return "Query";
                case IRepository:
                    return "Repository";
                default
                    return string.Empty;
            }
        }
    }
}



