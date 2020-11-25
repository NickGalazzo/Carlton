using Carlton.TestBed.Client.State;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.StatusSwitch.StatusChangeEvent
{
    public class StatusSwitchStatusChangeRequestHandler : TestBedEventRequestHandlerBase<StatusSwitchStatusChangeRequest>
    {
        public StatusSwitchStatusChangeRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<Unit> Handle(StatusSwitchStatusChangeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
