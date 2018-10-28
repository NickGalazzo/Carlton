using System;
using System.Threading.Tasks;
using Carlton.CQRS.Commands;
using Carlton.CQRS.Queries;
using Carlton.Infrastructure.Exceptions;

namespace Carlton.CQRS.Exceptions
{
    public class CqrsExceptionHandler : IExceptionHandler
    {
        public Task HandleException(Exception ex, object requestObj)
        {
            var type = ex.TargetSite.ReflectedType;

            switch (type)
            {
                case ICommandHandler c:
                    throw new CommandException(requestObj as ICommand, ex);
                case IQuery q:
                    throw new QueryException(requestObj as IQuery, ex);
                default:
                    throw new InvalidOperationException("Request is neither a command nor query, this should never happen");
            }
        }
    }
}
