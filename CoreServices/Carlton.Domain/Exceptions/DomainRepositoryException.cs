using Carlton.Domain.BusinessObjects;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.Domain.Exceptions
{
    public class DomainRepositoryException : BaseCarltonException
    {
        private const string ErrMessage = "An error occured inside a {0} repository";

        public IAggregateRoot Entity { get; }

        public DomainRepositoryException(IAggregateRoot entity, Exception innerException)
            : base(string.Format(ErrMessage, nameof(entity)), innerException)
        {
            this.Entity = entity;
        }
    }
}
