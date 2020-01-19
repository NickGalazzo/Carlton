using Carlton.Base.Domain.BusinessObjects;
using Carlton.Base.Infrastructure.Data.Repository;
using System.Collections.Generic;

namespace Carlton.Base.Domain.Repository
{
    public interface IReadOnlyDomainRepository<AggregateType, IdType> :
        IDomainRepository,
        IReadOnlyRepository<AggregateType, IdType>
        where AggregateType : IAggregateRoot
    {
        new AggregateType FindById(IdType id);
        new IEnumerable<AggregateType> FindAll();
    }
}