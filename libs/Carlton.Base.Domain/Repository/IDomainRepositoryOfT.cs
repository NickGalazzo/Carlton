using Carlton.Base.Domain.BusinessObjects;
using Carlton.Base.Infrastructure.Data.Repository;

namespace Carlton.Base.Domain.Repository
{
    public interface IDomainRepository<AggregateType, IdType> :
        IReadOnlyDomainRepository<AggregateType, IdType>,
        IRepository<AggregateType, IdType>
        where AggregateType : IAggregateRoot
    {
        new void Update(AggregateType aggregate);
        new void Insert(AggregateType aggregate);
        new void Delete(AggregateType aggregate);
    }
}
