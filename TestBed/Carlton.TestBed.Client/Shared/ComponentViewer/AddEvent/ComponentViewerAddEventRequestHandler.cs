using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.ComponentViewer
{
    public class ComponentViewerAddEventRequestHandler : TestBedEventRequestHandlerBase<ComponentViewerAddEventRequest>
    {
        public ComponentViewerAddEventRequestHandler(TestBedState state) : base(state)
        { 
        }

        public async override Task<Unit> Handle(ComponentViewerAddEventRequest request, CancellationToken cancellationToken)
        {
            await State.AddTestComponentEvents(request.Sender, request.ComponentEvent.evt);
            return Unit.Value;
        }
    }
}
