using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.EventConsole
{
    public class EventConsoleClearRequestHandler : TestBedEventRequestHandlerBase<EventConsoleClearRequest>
    {
        public EventConsoleClearRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<Unit> Handle(EventConsoleClearRequest request, CancellationToken cancellationToken)
        {
            State.ComponentEvents.Clear();
            return Task.FromResult(Unit.Value);
        }
    }
}
