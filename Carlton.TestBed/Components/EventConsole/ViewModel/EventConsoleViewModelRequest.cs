using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record EventConsoleViewModel(IEnumerable<object> ComponentEvents);

    public class EventConsoleViewModelRequest : IRequest<EventConsoleViewModel>
    {
    }

    public class EventConsoleViewModelRequestHandler : TestBedRequestHandlerViewModelBase<EventConsoleViewModelRequest, EventConsoleViewModel>
    {
        public EventConsoleViewModelRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<EventConsoleViewModel> Handle(EventConsoleViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new EventConsoleViewModel(State.ComponentEvents));
        }
    }
}
