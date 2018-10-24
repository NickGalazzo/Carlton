using Castle.DynamicProxy;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class CommandValidationInterceptor : IInterceptor
    {
        private readonly ILogger<CommandValidationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public CommandValidationInterceptor(ILogger<CommandValidationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Intercept(IInvocation invocation)
        {
            var command = invocation.Arguments[0];
            var commandType = command.GetType();

            var closedType = typeof(AbstractValidator<>).MakeGenericType(commandType);
            var validator = (IValidator)_provider.GetService(closedType);

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                _logger.LogDebug($"{commandType} failed validation");
                throw new ValidationException(result.Errors);
            }

            invocation.Proceed();
        }
    }
}
