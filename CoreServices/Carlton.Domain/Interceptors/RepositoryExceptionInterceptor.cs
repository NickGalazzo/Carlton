using Carlton.Domain.DDD;
using Carlton.Domain.Exceptions;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class RepositoryExceptionInterceptor : IInterceptor
    {
        private readonly ILogger<RepositoryExceptionInterceptor> _logger;

        public RepositoryExceptionInterceptor(ILogger<RepositoryExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            using (_logger.BeginScope(invocation.TargetType))
            {
                try
                {
                    _logger.LogInformation($"Entering Repository Handler of type: {invocation.TargetType}");
                    invocation.Proceed();
                    _logger.LogInformation($"Exiting Repository Handler of type: {invocation.TargetType}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in Repository of type: {invocation.TargetType}");
                    throw new RepositoryException(invocation.Arguments[0] as IAggregateRoot, $"Error occured in {invocation.TargetType} repository.", ex);
                }
            }
        }
    }
}
