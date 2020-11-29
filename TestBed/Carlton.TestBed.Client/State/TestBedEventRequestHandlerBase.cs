using MediatR;
using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.State
{
    public abstract class TestBedEventRequestHandlerBase<TRequest> : ComponentEventRequestHandlerBase<TRequest, TestBedState>
        where TRequest : IRequest<Unit>
    {
        public TestBedEventRequestHandlerBase(TestBedState state) : base(state)
        {
        }
    }
}
