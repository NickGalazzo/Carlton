using MediatR;
using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.EventConsole
{
    public class EventConsoleClearRequest : ComponentEventRequestBase<EventConsoleClearEvent>
    {
        public EventConsoleClearRequest(object sender, EventConsoleClearEvent evt) : base(sender, evt)
        {
        }
    }
}
