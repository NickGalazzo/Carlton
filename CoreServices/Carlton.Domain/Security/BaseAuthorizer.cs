using Carlton.Domain.Commands;
using Microsoft.AspNetCore.Http;
using System;

namespace Carlton.Domain.Security
{
    public abstract class BaseAuthorizer<T> : IAuthorizer<T>
    {
        protected IHttpContextAccessor Context { get; }

        protected BaseAuthorizer(IHttpContextAccessor context)
        {
            Context = context;
        }

        public bool IsAuthorized(object instance)
        {
            if (!(instance is ICommand command))
                throw new ArgumentException("Argument is not a Command");

            return IsAuthorized(command);
        }

        public abstract bool IsAuthorized(T instance);
    }
}


var requstType = request.GetType();

            if (!_authorizer.IsAuthorized(request))
            {
                _logger.LogInformation($"Unauthorized access attempt on {requstType}");
                throw new UnauthorizedAccessException("User attempting to access resource they are not authorized to");
            }

            _logger.LogDebug($"Access to {requstType} granted");

            return await next();