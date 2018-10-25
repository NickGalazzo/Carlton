using Microsoft.AspNetCore.Http;

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
            return IsAuthorized((T) instance);
        }

        public abstract bool IsAuthorized(T instance);
    }
}


