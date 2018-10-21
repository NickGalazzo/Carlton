using Carlton.Domain.DDD;
using System;

namespace Carlton.Domain.Repository
{
    public abstract class BaseUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IServiceProvider _provider;
        public BaseUnitOfWork(IServiceProvider provider)
        {
            _provider = provider; 
        }

        public IRepository<TAggregateRoot, IdType> GetRepository<TAggregateRoot, IdType>() where TAggregateRoot : IAggregateRoot
        {
           var repository =  (IRepository<TAggregateRoot, IdType>)_provider.GetService(typeof(IRepository<TAggregateRoot, IdType>));
           return repository;
        }

        public abstract void BeginTransaction();
        public abstract void Commit();
        public abstract void Rollback();
        public abstract void Dispose();
    }
}
