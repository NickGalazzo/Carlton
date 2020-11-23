using System;
using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.StatusSwitch
{
    public class StatusSwitchViewModelRequestHandler : ViewModelRequestHandlerBase<StatusSwitchViewModelRequest, StatusSwitchViewModel>
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
