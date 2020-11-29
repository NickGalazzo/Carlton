using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State
{
    public abstract class ComponentEventRequestHandlerBase<TRequest, TState> : IRequestHandler<TRequest, Unit>
        where TRequest : IRequest<Unit>
    {
        protected TState State { get; init; }
        
        public ComponentEventRequestHandlerBase(TState state) => State = state;

        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
