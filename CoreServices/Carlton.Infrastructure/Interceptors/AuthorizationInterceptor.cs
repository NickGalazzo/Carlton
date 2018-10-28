using Carlton.Infrastructure.Security;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Infrastructure.Interceptors
{
    public class AuthorizationInterceptor : BaseInterceptor
    {
        private readonly ILogger<AuthorizationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public AuthorizationInterceptor(ILogger<AuthorizationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public override void InterceptBehavior(IInvocation invocation)
        {
            var arg = invocation.Arguments[0];
            var argType = arg.GetType();

            var closedType = typeof(BaseAuthorizer<>).MakeGenericType(argType);
            var authorizer = (IAuthorizer)_provider.GetService(closedType);

            _logger.LogDebug($"Attempting to authorize user accessing: {argType}");

            if (!authorizer.IsAuthorized(arg))
            {
                _logger.LogInformation($"Unauthorized access attempt on {argType}");
                throw new UnauthorizedAccessException("User attempting to access resource they are not authorized to");
            }

            _logger.LogDebug($"Access to {argType} granted");

            invocation.Proceed();
        }
    }
}




