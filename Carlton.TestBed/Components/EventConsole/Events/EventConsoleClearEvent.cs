using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record EventConsoleClearEvent();
    
    public class EventConsoleClearRequest : ComponentEventRequestBase<EventConsoleClearEvent>
    {
        public EventConsoleClearRequest(object sender, EventConsoleClearEvent evt) : base(sender, evt)
        {
        }
    }

    public class EventConsoleClearRequestHandler : TestBedEventRequestHandlerBase<EventConsoleClearRequest>
    {
        public EventConsoleClearRequestHandler(TestBedState state) : base(state)
        {
        }

        public async override Task<Unit> Handle(EventConsoleClearRequest request, CancellationToken cancellationToken)
        {
            await State.ClearComponentEvents(request.Sender);
            return Unit.Value;
        }
    }
}
