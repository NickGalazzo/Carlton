using Carlton.Domain.DDD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Domain.Repository
{
    public interface IReadOnlyRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        AggregateType FindBy(IdType id);
        IEnumerable<AggregateType> FindAll();
        IEnumerable<AggregateType> FindBy(Expression<Func<AggregateType, bool>> predicate);
    }
}