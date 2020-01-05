using Castle.DynamicProxy;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Infrastructure.Interceptors
{
    public class ValidationInterceptor : BaseInterceptor
    {
        private readonly ILogger<ValidationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public ValidationInterceptor(ILogger<ValidationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public override void InterceptBehavior(IInvocation invocation)
        {
            var arg = invocation.Arguments[0];
            var argType = arg.GetType();

            var closedType = typeof(AbstractValidator<>).MakeGenericType(argType);
            var validator = (IValidator)_provider.GetService(closedType);

            var result = validator.Validate(argType);

            _logger.LogDebug($"{argType} is about to be validated");

            if (!result.IsValid)
            {
                _logger.LogInformation($"{argType} failed validation");
                throw new ValidationException(result.Errors);
            }

            _logger.LogDebug($"{argType} passed validation");

            invocation.Proceed();
        }
    }
}
