using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Base
{
    public interface IReadOnlyRepository<T, IdType>
    {
        Task<T> FindById(IdType id);
        Task<IEnumerable<T>> FindAll();
    }
}
