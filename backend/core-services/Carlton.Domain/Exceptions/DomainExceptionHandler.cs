using Carlton.Domain.BusinessObjects;
using Carlton.Domain.DomainEvents;
using Carlton.Domain.Repository;
using Carlton.Infrastructure.Exceptions;
using System;
using System.Threading.Tasks;

namespace Carlton.Domain.Exceptions
{
    public class DomainExceptionHandler : IExceptionHandler
    {
        public Task HandleException(Exception ex, object requestObj)
        {
            var type = ex.TargetSite.ReflectedType;

            switch (type)
            {
                case IDomainObject d:
                    throw new DomainException(requestObj as IDomainObject, ex);
                case IDomainRepository r:
                    throw new DomainRepositoryException(requestObj as IAggregateRoot, ex);
                case IDomainEventHandler h:
                    throw new DomainEventException(requestObj as IDomainEvent, ex);
                default:
                    throw new InvalidOperationException("Request is not a domain object, this should never happen");
            }
        }
    }
}
