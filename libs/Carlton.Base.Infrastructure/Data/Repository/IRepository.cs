using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Data.Repository
{
    public interface IRepository<T, IdType> : IReadOnlyRepository<T, IdType>
    {
        Task Update(T entity);
        Task Insert(T entity);
        Task Delete(T entity);
    }
}
