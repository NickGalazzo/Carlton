using Carlton.Domain.Repository;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Carlton.Domain.Interceptors
{
    public class TransactionInterceptor : IInterceptor
    {
        private readonly ILogger<TransactionInterceptor> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionInterceptor(ILogger<TransactionInterceptor> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.LogDebug("Begining Transaction");
            _unitOfWork.BeginTransaction();
            invocation.Proceed();
            _unitOfWork.Commit();
            _logger.LogDebug("Transaction Committed");
        }
    }
}
