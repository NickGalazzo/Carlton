using System;
using System.Threading.Tasks;
using Carlton.Domain.Commands;
using Carlton.Domain.DDD;
using Carlton.Domain.Queries;
using Carlton.Domain.Repository;
using Carlton.Infrastructure.Exceptions;

namespace Carlton.Domain.Exceptions
{
    public class CqrsExceptionHandler : IExceptionHandler
    {
        public Task HandleException(Exception ex, object requestObj)
        {
            var type = ex.TargetSite.ReflectedType;
            var typeName = nameof(type);

            switch (type)
            {
                case ICommandHandler c:
                    throw new CommandException(requestObj as ICommand, $"Error occured while executing command {typeName}", ex);
                case IQuery q:
                    throw new QueryException(requestObj as IQuery, $"Error occured while executing query {typeName}", ex);
                case IDomainRepository r:
                    throw new DomainRepositoryException(requestObj as IAggregateRoot, $"Error occured while accessing repository {typeName}", ex);
                default:
                    throw new ArgumentException("Request is neither a command nor query; this should never happen");
            }
        }
    }
}
