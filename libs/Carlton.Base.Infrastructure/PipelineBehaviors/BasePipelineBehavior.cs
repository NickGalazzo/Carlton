using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.PipelineBehaviors
{
    public abstract class BasePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        protected readonly ILogger Logger;

        protected string RequestType
        {
            get { return $"{typeof(TRequest).Name} Request"; }
        }

        public BasePipelineBehavior(ILogger logger)
        {
            Logger = logger;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}
