using Castle.DynamicProxy;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class ValidationInterceptor : IInterceptor
    {
        private readonly ILogger<ValidationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public ValidationInterceptor(ILogger<ValidationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Intercept(IInvocation invocation)
        {
            var arg = invocation.Arguments[0];
            var argType = arg.GetType();

            var closedType = typeof(AbstractValidator<>).MakeGenericType(argType);
            var validator = (IValidator)_provider.GetService(closedType);

            var result = validator.Validate(argType);

            _logger.LogDebug($"{argType} is about to be validated");

            if (!result.IsValid)
            {
                _logger.LogWarning($"{argType} failed validation");
                throw new ValidationException(result.Errors);
            }

            invocation.Proceed();
        }
    }
}
