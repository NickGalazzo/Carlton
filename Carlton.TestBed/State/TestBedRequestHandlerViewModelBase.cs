using MediatR;
using Carlton.Base.Client.State;

namespace Carlton.TestBed.State
{
    public abstract class TestBedRequestHandlerViewModelBase<TRequest, TViewModel> : ViewModelRequestHandlerBase<TRequest, TViewModel, TestBedState>
        where TRequest : IRequest<TViewModel>
    {
        public TestBedRequestHandlerViewModelBase(TestBedState state) : base(state)
        {
        }
    }
}
