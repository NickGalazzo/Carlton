using Carlton.Base.Client.State;
using Carlton.TestBed.Client.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.StatusSwitch
{
    public record StatusSwitchStatusChangedEvent(ComponentStatus ComponentStatus);

    public class StatusSwitchStatusChangeRequest : ComponentEventRequestBase<StatusSwitchStatusChangedEvent>
    {
        public StatusSwitchStatusChangeRequest(object sender, StatusSwitchStatusChangedEvent evt) : base(sender, evt)
        {
        }
    }

    public class StatusSwitchStatusChangeRequestHandler : TestBedEventRequestHandlerBase<StatusSwitchStatusChangeRequest>
    {
        public StatusSwitchStatusChangeRequestHandler(TestBedState state) : base(state)
        {
        }

        public async override Task<Unit> Handle(StatusSwitchStatusChangeRequest request, CancellationToken cancellationToken)
        {
            await State.UpdateComponentStatus(request.Sender, request.ComponentEvent.ComponentStatus);
            return Unit.Value;
        }
    }
}
