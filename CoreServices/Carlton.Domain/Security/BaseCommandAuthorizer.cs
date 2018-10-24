using Carlton.Domain.Commands;
using Microsoft.AspNetCore.Http;

namespace Carlton.Domain.Security
{
    public abstract class BaseCommandAuthorizer<T> : BaseAuthorizer where T : ICommand
    {
        public BaseCommandAuthorizer(IHttpContextAccessor context) : base(context)
        {
        }

        public abstract bool IsAuthorized(ICommand command);
    }
}
