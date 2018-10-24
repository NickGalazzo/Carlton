using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Transactions;

namespace Carlton.Domain.Repository
{
    public class DapperUnitOfWork : BaseUnitOfWork
    {
        private IDbConnection _connection;
        private TransactionScope _scope;
        private ILogger<DapperUnitOfWork> _logger;

        public DapperUnitOfWork(IDbConnection connection, IServiceProvider serviceProvider, ILogger<DapperUnitOfWork> logger) : base(serviceProvider)
        {
            _connection = connection;
            _logger = logger;
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
            catch(Exception ex)
            {
                _logger.LogWarning(ex, "Exception was thrown and transaction will be rolled back.");
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
