using Carlton.Base.Domain.BusinessObjects;
using Carlton.Base.Infrastructure.Exceptions;
using System;

namespace Carlton.Base.Domain.Exceptions
{
    public class DomainRepositoryException : CarltonBaseException
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
