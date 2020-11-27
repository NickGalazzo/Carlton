using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;
using Microsoft.AspNetCore.Components;

namespace Carlton.TestBed.Client.Shared.ModelViewer
{
    public class ModelViewerModelChangeRequestHandler : TestBedEventRequestHandlerBase<ModelViewerModelChangeRequest>
    {
        public ModelViewerModelChangeRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<Unit> Handle(ModelViewerModelChangeRequest request, CancellationToken cancellationToken)
        {
            State.UpdateTestComponentViewModel(request.Sender, request.ComponentEvent.ComponentViewModel);
            return Task.FromResult(Unit.Value);
        }
    }
}
