using Carlton.Domain.Commands;
using Carlton.Domain.DDD;
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
            var typeName = nameof(invocation.TargetType);

            using (_logger.BeginScope(typeName))
                try
                {
                    _logger.LogInformation($"Entering Handler of type: {invocation.TargetType}");
                    invocation.Proceed();
                    _logger.LogInformation($"Exiting Handler of type: {invocation.TargetType}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in Repository of type: {typeName}");

                    switch (invocation.InvocationTarget)
                    {
                        case ICommandHandler c:
                            throw new CommandException(invocation.Arguments[0] as ICommand, $"Error occured while executing command {typeName}", ex);
                        case IQuery q:
                            throw new QueryException(invocation.Arguments[0] as IQuery, $"Error occured while executing query {typeName}", ex);
                        case IRepository r:
                            throw new RepositoryException(invocation.Arguments[0] as IAggregateRoot, $"Error occured while accessing repository {typeName}", ex);
                        default:
                            throw new ArgumentException("Request is neither a command nor query; this should never happen");
                    }
                }
        }
    }
}



