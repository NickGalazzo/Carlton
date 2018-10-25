using Carlton.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Carlton.Domain.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(ILogger<TransactionBehavior<TRequest, TResponse>> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogDebug("Begining Transaction");
            _unitOfWork.BeginTransaction();
            var response = await next();
            _unitOfWork.Commit();
            _logger.LogDebug("Transaction Committed");
            return response;
        }
    }
}
