using Carlton.Domain.DDD;
using Carlton.Infrastructure.Data.Repository;

namespace Carlton.Domain.Repository
{
    public interface IDomainRepository<AggregateType, IdType> :
        IReadOnlyDomainRepository<AggregateType, IdType>, 
        IRepository<AggregateType, IdType>
        where AggregateType: IAggregateRoot
    {
        new void Update(AggregateType aggregate);
        new void Insert(AggregateType aggregate);
        new void Delete(AggregateType aggregate);
    }
}
