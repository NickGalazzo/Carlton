using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.Domain.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
        private readonly AbstractValidator<TRequest> _validator;

        public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger, AbstractValidator<TRequest> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestType = request.GetType();

            _logger.LogDebug($"About to validate: {requestType}");

            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                _logger.LogWarning($"{requestType} failed validation");
                throw new ValidationException(result.Errors);
            }

            _logger.LogDebug($"{requestType} passed validation");

            return await next();
        }
    }
}
