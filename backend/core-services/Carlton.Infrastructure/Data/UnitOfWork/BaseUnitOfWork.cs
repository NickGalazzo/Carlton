using Carlton.Infrastructure.Data.Repository.Base;
using System;

namespace Carlton.Infrastructure.Data.UnitOfWork
{
    public abstract class BaseUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IServiceProvider _provider;
        public BaseUnitOfWork(IServiceProvider provider)
        {
            _provider = provider; 
        }

        public IRepository<T, IdType> GetRepository<T, IdType>() 
        {
           var repository =  (IRepository<T, IdType>)_provider.GetService(typeof(IRepository<T, IdType>));
           return repository;
        }

        public abstract void BeginTransaction();
        public abstract void Commit();
        public abstract void Rollback();
        public abstract void Dispose();
    }
}
