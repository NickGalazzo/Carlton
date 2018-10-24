using Carlton.Domain.Commands;
using Carlton.Domain.Security;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class CommandAuthorizationInterceptor 
    {
        private readonly ILogger<CommandAuthorizationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public CommandAuthorizationInterceptor(ILogger<CommandAuthorizationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Intercept(IInvocation invocation)
        {
            var command = invocation.Arguments[0];
            var commandType = command.GetType();

            var closedType = typeof(BaseCommandAuthorizer<>).MakeGenericType(commandType);
            var authorizer = (BaseCommandAuthorizer<ICommand>) _provider.GetService(closedType);

            if (!authorizer.IsAuthorized((ICommand)command))
            {
                _logger.LogInformation($"Unauthorized access attempt on command {commandType}");
                throw new UnauthorizedAccessException("User attempting to access resource they are not authorized to");
            }

            invocation.Proceed();

            _logger.LogDebug($"Access to command {commandType} granted");
        }
    }
}



