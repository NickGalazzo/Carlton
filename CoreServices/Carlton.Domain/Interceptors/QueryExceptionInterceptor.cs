using Carlton.Domain.Exceptions;
using Carlton.Domain.Queries;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class QueryExceptionInterceptor 
    {
        private readonly ILogger<QueryExceptionInterceptor> _logger;

        public QueryExceptionInterceptor(ILogger<QueryExceptionInterceptor> logger) 
        {
        }

        public void Intercept(IInvocation invocation)
        {
            using (_logger.BeginScope(invocation.TargetType))
                try
                {
                    _logger.LogInformation($"Entering Query Handler of type: {invocation.TargetType}");
                    invocation.Proceed();
                    _logger.LogInformation($"Exiting Query Handler of type: {invocation.TargetType}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in Repository of type: {invocation.TargetType}");
                    throw new QueryException(invocation.Arguments[0] as IQuery, $"Error occured while executing query {invocation.TargetType}", ex);
                }
        }
    }
}



