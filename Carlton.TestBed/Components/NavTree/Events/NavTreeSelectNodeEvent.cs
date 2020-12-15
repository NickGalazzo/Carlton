using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record NavTreeSelectedNodeEvent(int SelectedItemId);

    public class NavTreeSelectNodeRequest : ComponentEventRequestBase<NavTreeSelectedNodeEvent>
    {
        public NavTreeSelectNodeRequest(object sender, NavTreeSelectedNodeEvent componentEvent)
            :base(sender, componentEvent)
        {
        }
    }
    
    public class NavTreeSelectNodeRequestHandler : TestBedEventRequestHandlerBase<NavTreeSelectNodeRequest>
    {
        public NavTreeSelectNodeRequestHandler(TestBedState state) : base(state)
        {
        }

        public async override Task<Unit> Handle(NavTreeSelectNodeRequest request, CancellationToken cancellationToken)
        {
            await State.UpdateSelectedItemId(request.Sender, request.ComponentEvent.SelectedItemId);
            return Unit.Value;
        }
    }
}
