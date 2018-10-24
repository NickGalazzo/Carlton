using Carlton.Domain.Queries;
using Microsoft.AspNetCore.Http;

namespace Carlton.Domain.Security
{
    public abstract class BaseQueryAuthorizer<T> : BaseAuthorizer where T : IQuery
    {
        public BaseQueryAuthorizer(IHttpContextAccessor context) : base(context)
        {
        }

        public abstract bool IsAuthorized(IQuery query);
    }
}
