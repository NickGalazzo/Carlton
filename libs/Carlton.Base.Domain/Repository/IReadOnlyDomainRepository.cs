using Carlton.Base.Domain.BusinessObjects;
using Carlton.Base.Infrastructure.Data.Repository;
using System.Collections.Generic;

namespace Carlton.Base.Domain.Repository
{
    public interface IReadOnlyDomainRepository<TAggregate, TId> :
        IDomainRepository,
        IReadOnlyRepository<TAggregate, TId>
        where TAggregate : IAggregateRoot
    {
        new TAggregate FindById(TId id);
        new IEnumerable<TAggregate> FindAll();
    }
}