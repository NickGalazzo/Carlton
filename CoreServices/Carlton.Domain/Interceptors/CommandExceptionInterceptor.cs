using Carlton.Domain.Commands;
using Carlton.Domain.Exceptions;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class CommandExceptionInterceptor
    {
        private readonly ILogger<CommandExceptionInterceptor> _logger;

        public CommandExceptionInterceptor(ILogger<CommandExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            using (_logger.BeginScope(invocation.TargetType))
                try
                {
                    _logger.LogInformation($"Entering Command Handler of type: {invocation.TargetType}");
                    invocation.Proceed();
                    _logger.LogInformation($"Exiting Command Handler of type: {invocation.TargetType}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in Repository of type: {invocation.TargetType}");
                    throw new CommandException(invocation.Arguments[0] as ICommand, $"Error occured while executing command {invocation.TargetType}", ex);
                }
        }
    }
}



