using Carlton.Infrastructure.Data.Base;
using Carlton.Infrastructure.Data.Repository.Base;
using Carlton.Infrastructure.Data.Repository.Dapper.Contracts;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc.Contracts
{
    public interface IReadOnlySprocRepository<T, IdType> : IReadOnlyRepository<T, IdType>
    {
        Task<PagedResult<T>> Find<TSprocParams>(ISprocSpecification<T, TSprocParams> specification);
        Task<PagedResult<T>> Find<TSprocParams>(ISprocSpecification<T , TSprocParams> specification, IQueryConstraints<T> constraints);
    }
}
