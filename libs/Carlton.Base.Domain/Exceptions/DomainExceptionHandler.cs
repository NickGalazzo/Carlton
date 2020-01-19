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

            throw type switch
            {
                IDomainObject _ => new DomainException(requestObj as IDomainObject, ex),
                IDomainRepository _ => new DomainRepositoryException(requestObj as IAggregateRoot, ex),
                IDomainEventHandler _ => new DomainEventException(requestObj as IDomainEvent, ex),
                _ => new InvalidOperationException("Request is not a domain object, this should never happen"),
            };
        }
    }
}
