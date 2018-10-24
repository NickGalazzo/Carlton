using Carlton.Domain.Security;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.Domain.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<AuthorizationBehavior<TRequest, TResponse>> _logger;
        private readonly BaseAuthorizer<TRequest> _authorizer;

        public AuthorizationBehavior(ILogger<AuthorizationBehavior<TRequest, TResponse>> logger,
            BaseAuthorizer<TRequest> authorizer)
        {
            _logger = logger;
            _authorizer = authorizer;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requstType = request.GetType();

            _logger.LogWarning($"Attempting to authorize user accessing: {requstType}");

            if (!_authorizer.IsAuthorized(request))
            {
                _logger.LogWarning($"Unauthorized access attempt on {requstType}");
                throw new UnauthorizedAccessException("User attempting to access resource they are not authorized to");
            }

            _logger.LogDebug($"Access to {requstType} granted");

            return await next();
        }
    }
}
