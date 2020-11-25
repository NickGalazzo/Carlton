using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.EventConsole
{
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
