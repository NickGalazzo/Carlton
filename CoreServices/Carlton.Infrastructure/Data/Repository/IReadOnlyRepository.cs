using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Infrastructure.Data.Repository
{
    public interface IReadOnlyRepository<T, IdType>
    {
        T FindById(IdType id);
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
