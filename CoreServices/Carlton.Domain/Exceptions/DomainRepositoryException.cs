using Carlton.Domain.DDD;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.Domain.Exceptions
{
    public class DomainRepositoryException : BaseCarltonException
    {
        public IAggregateRoot Entity { get; }

        public DomainRepositoryException(IAggregateRoot entity)
        {
            Entity = entity;
        }

        public DomainRepositoryException(IAggregateRoot entity, string message) : base(message)
        {
            Entity = entity;
        }

        public DomainRepositoryException(IAggregateRoot entity, string message, Exception innerException) : base(message, innerException)
        {
            Entity = entity;
        }
    }
}
