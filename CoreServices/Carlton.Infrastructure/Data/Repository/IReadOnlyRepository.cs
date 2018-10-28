using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Infrastructure.Data.Repository
{
    public interface IReadOnlyRepository<T, IdType>
    {
        T FindBy(IdType id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
