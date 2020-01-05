using Carlton.CQRS.Queries;
using Carlton.Infrastructure.Security;
using Microsoft.AspNetCore.Http;

namespace Carlton.CQRS.Security
{
    public abstract class BaseQueryAuthorizer<T> : BaseAuthorizer<T> where T : IQuery
    {
        protected BaseQueryAuthorizer(IHttpContextAccessor context) : base(context)
        {
        }
    }
}
