using Carlton.Domain.DDD;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.Domain.Exceptions
{
    public class RepositoryException : BaseCarltonException
    {
        public IAggregateRoot Entity { get; }

        public RepositoryException(IAggregateRoot entity)
        {
            Entity = entity;
        }

        public RepositoryException(IAggregateRoot entity, string message) : base(message)
        {
            Entity = entity;
        }

        public RepositoryException(IAggregateRoot entity, string message, Exception innerException) : base(message, innerException)
        {
            Entity = entity;
        }
    }
}
