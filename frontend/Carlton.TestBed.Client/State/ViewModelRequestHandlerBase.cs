using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Carlton.TestBed.Client.State
{
    public abstract class ViewModelRequestHandlerBase<TRequest, TViewModel> : IRequestHandler<TRequest, TViewModel>
        where TRequest : IRequest<TViewModel>
    {
        protected TestBedState State { get; private set; }

        public ViewModelRequestHandlerBase(TestBedState state)
        {
            State = state;
        }

        public abstract Task<TViewModel> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
