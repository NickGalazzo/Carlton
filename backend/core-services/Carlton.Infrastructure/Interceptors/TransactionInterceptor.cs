using Carlton.Infrastructure.Data.UnitOfWork;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Carlton.Infrastructure.Interceptors
{
    public class TransactionInterceptor : BaseInterceptor
    {
        private readonly ILogger<TransactionInterceptor> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionInterceptor(ILogger<TransactionInterceptor> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public override void InterceptBehavior(IInvocation invocation)
        {
            _logger.LogInformation("Begining Transaction");
            _unitOfWork.BeginTransaction();
            invocation.Proceed();
            _unitOfWork.Commit();
            _logger.LogInformation("Transaction Committed");
        }
    }
}
