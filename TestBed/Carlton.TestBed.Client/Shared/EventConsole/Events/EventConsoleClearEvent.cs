using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.EventConsole
{
    public record EventConsoleClearEvent();
    
    public class EventConsoleClear : ComponentEventRequestBase<EventConsoleClearEvent>
    {
        public EventConsoleClear(object sender, EventConsoleClearEvent evt) : base(sender, evt)
        {
        }
    }
    public class EventConsoleClearRequestHandler : TestBedEventRequestHandlerBase<EventConsoleClear>
    {
        public EventConsoleClearRequestHandler(TestBedState state) : base(state)
        {
        }

        public async override Task<Unit> Handle(EventConsoleClear request, CancellationToken cancellationToken)
        {
            await State.ClearComponentEvents(request.Sender);
            return Unit.Value;
        }
    }
}
