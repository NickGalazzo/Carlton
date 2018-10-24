using Carlton.Domain.Queries;
using Carlton.Domain.Security;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class QueryAuthorizationInterceptor
    {
        private readonly ILogger<QueryAuthorizationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public QueryAuthorizationInterceptor(ILogger<QueryAuthorizationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Intercept(IInvocation invocation)
        {
            var query = invocation.Arguments[0];
            var queryType = query.GetType();

            var closedType = typeof(BaseQueryAuthorizer<>).MakeGenericType(queryType);
            var authorizer = (BaseQueryAuthorizer<IQuery>)_provider.GetService(closedType);

            if (!authorizer.IsAuthorized((IQuery)query))
            {
                _logger.LogInformation($"Unauthorized access attempt on query {queryType}");
                throw new UnauthorizedAccessException("User attempting to access resource they are not authorized to");
            }

            invocation.Proceed();

            _logger.LogDebug($"Access to query {queryType} granted");
        }
    }
}


