using Carlton.Domain.BusinessObjects;
using Carlton.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Domain.Repository
{
    public interface IReadOnlyDomainRepository<AggregateType, IdType> : 
        IDomainRepository,
        IReadOnlyRepository<AggregateType, IdType>
        where AggregateType : IAggregateRoot
    {
        new AggregateType FindById(IdType id);
        new IEnumerable<AggregateType> FindAll();
        new IEnumerable<AggregateType> Find(Expression<Func<AggregateType, bool>> predicate);
    }
}