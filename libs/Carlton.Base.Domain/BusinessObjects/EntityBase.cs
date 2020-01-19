
using Carlton.Base.Domain.DomainEvents;
using System;
using System.Collections.Generic;

namespace Carlton.Base.Domain.BusinessObjects
{
    public abstract class EntityBase<IdType> : IDomainObject, IEquatable<EntityBase<IdType>>
    {
        private List<IDomainEvent> _domainEvents;

        public IdType Id { get; }
        private List<IDomainEvent> DomainEvents {get;}

        public EntityBase(IdType id)
        {
            Id = id;
        }

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            if (entity1 is null && entity2 is null)
            {
                return true;
            }

            if (entity1 is null || entity2 is null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            return (!(entity1 == entity2));
        }

        public bool Equals(EntityBase<IdType> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is EntityBase<IdType>
               && this == (EntityBase<IdType>)entity;
        }
    }
}
