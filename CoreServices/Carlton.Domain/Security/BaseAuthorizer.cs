using Microsoft.AspNetCore.Http;

namespace Carlton.Domain.Security
{
    public abstract class BaseAuthorizer
    {
        protected IHttpContextAccessor Context { get; }

        public BaseAuthorizer(IHttpContextAccessor context)
        {
            Context = context;
        }
    }
}
