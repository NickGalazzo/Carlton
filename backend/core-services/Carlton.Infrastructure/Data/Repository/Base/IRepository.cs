using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Base
{
    public interface IRepository<T, IdType> : IReadOnlyRepository<T, IdType>
    {
        Task Update(T entity);
        Task Insert(T entity);
        Task Delete(T entity);
    }
}
