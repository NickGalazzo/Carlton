using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.State;


namespace Carlton.TestBed.Components
{
    public record StatusSwitchViewModel(ComponentStatus TestComponentStatus);

    public class StatusSwitchViewModelRequest : IRequest<StatusSwitchViewModel>
    {
    }

    public class StatusSwitchViewModelRequestHandler : TestBedRequestHandlerViewModelBase<StatusSwitchViewModelRequest, StatusSwitchViewModel>
    {
        public StatusSwitchViewModelRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<StatusSwitchViewModel> Handle(StatusSwitchViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new StatusSwitchViewModel(State.TestComponentStatus));
        }
    }
}
