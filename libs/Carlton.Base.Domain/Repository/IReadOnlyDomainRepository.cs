using Carlton.Domain.BusinessObjects;
using Carlton.Infrastructure.Data.Repository.Base;
using System.Collections.Generic;

namespace Carlton.Domain.Repository
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