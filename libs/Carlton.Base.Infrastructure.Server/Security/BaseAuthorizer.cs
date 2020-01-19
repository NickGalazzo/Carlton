using Carlton.Base.Infrastructure.Security;
using Microsoft.AspNetCore.Http;

namespace Carlton.Base.Infrastructure.Server.Security
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


