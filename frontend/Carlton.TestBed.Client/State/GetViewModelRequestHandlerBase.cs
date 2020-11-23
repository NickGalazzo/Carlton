using Carlton.Base.Client.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.State
{
    public abstract class GetViewModelRequestHandlerBase<TRequest, TViewModel> : IRequestHandler<TRequest, TViewModel>
        where TRequest : IRequest<TViewModel>
    {
        protected CarltonTestBedState State { get; private set; }

        public GetViewModelRequestHandlerBase(CarltonTestBedState state)
        {
            State = state;
        }

        public abstract Task<TViewModel> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
