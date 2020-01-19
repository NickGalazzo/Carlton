using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Data.Repository
{
    public interface IReadOnlyRepository<T, IdType>
    {
        Task<T> FindById(IdType id);
        Task<IEnumerable<T>> FindAll();
    }
}
