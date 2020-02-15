﻿using Carlton.Base.Domain.DomainEvents;
using Carlton.Base.Infrastructure.Exceptions;
using System;

namespace Carlton.Base.Domain.Exceptions
{
    public class DomainEventException : CarltonBaseException
    {
        private const string ErrMessage = "An error occured inside a domain event handler {0}";
        public IDomainEvent DomainEvent { get; }

        public DomainEventException(IDomainEvent domainEvent, Exception innerException)
            : base(string.Format(ErrMessage, nameof(domainEvent)), innerException)
        {
            this.DomainEvent = domainEvent;
        }
    }
}