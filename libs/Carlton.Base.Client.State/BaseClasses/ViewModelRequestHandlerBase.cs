using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Carlton.Base.Client.State
{
    public abstract class ViewModelRequestHandlerBase<TRequest, TViewModel, TState> : IRequestHandler<TRequest, TViewModel>
        where TRequest : IRequest<TViewModel>
    {
        protected TState State { get; private set; }

        public ViewModelRequestHandlerBase(TState state) => State = state;

        public abstract Task<TViewModel> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
