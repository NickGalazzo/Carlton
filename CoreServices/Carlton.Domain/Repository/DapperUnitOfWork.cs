using System;
using System.Data;
using System.Transactions;

namespace Carlton.Domain.Repository
{
    public class DapperUnitOfWork : BaseUnitOfWork
    {
        private IDbConnection _connection;
        private TransactionScope _scope;

        public DapperUnitOfWork(IDbConnection connection, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _connection = connection;
        }

        public override void BeginTransaction()
        {
            _scope = new TransactionScope();
            _connection.Open();
        }

        public override void Commit()
        {
            try
            {
                _scope.Complete();
            }
            finally
            {
                Dispose();
            }
        }

        public override void Rollback()
        {
            _scope.Dispose();
            _scope = null;
        }

        public override void Dispose()
        {
            _scope?.Dispose();
            _scope = null;
            _connection.Close();
            _connection.Dispose();
        }
    }
}
