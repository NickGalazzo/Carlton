using Carlton.CQRS.Commands;
using Carlton.Infrastructure.Security;
using Microsoft.AspNetCore.Http;

namespace Carlton.CQRS.Security
{
    public abstract class BaseCommandAuthorizer<T> : BaseAuthorizer<T> where T : class, ICommand
    {
        protected BaseCommandAuthorizer(IHttpContextAccessor context) : base(context)
        {
        }
    }
}
