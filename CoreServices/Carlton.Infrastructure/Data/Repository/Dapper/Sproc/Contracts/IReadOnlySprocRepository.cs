using Carlton.Infrastructure.Data.Base;
using Carlton.Infrastructure.Data.Repository.Base;
using Carlton.Infrastructure.Data.Repository.Dapper.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc.Contracts
{
    public interface IReadOnlySprocRepository<T, IdType> : IReadOnlyRepository<T, IdType>
    {
        Task<IEnumerable<T>> Find(ISprocSpecification<T> specification);
        Task<PagedResult<T>> Find(ISprocSpecification<T> specification, IQueryConstraints<T> constraints);
    }
}
