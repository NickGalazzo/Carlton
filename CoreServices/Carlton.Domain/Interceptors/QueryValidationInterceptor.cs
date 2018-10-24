using Castle.DynamicProxy;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Carlton.Domain.Interceptors
{
    public class QueryValidationInterceptor : IInterceptor
    {
        private readonly ILogger<QueryValidationInterceptor> _logger;
        private readonly IServiceProvider _provider;

        public QueryValidationInterceptor(ILogger<QueryValidationInterceptor> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Intercept(IInvocation invocation)
        {
            var query = invocation.Arguments[0];
            var queryType = query.GetType();

            var closedType = typeof(AbstractValidator<>).MakeGenericType(queryType);
            var validator = (IValidator)_provider.GetService(closedType);

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                _logger.LogDebug($"{queryType} failed validation");
                throw new ValidationException(result.Errors);
            }

            invocation.Proceed();
        }
    }
}

