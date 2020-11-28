using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MediatR;
using Carlton.TestBed.Client.State;


namespace Carlton.TestBed.Client.Shared.ModelViewer
{
    public class ModelViewerModelChangeRequestHandler : TestBedEventRequestHandlerBase<ModelViewerModelChangeRequest>
    {
        public ModelViewerModelChangeRequestHandler(TestBedState state) : base(state)
        {
        }

        public async override Task<Unit> Handle(ModelViewerModelChangeRequest request, CancellationToken cancellationToken)
        {
            await State.UpdateTestComponentViewModel(request.Sender, request.ComponentEvent.ComponentViewModel);
            return Unit.Value;
        }
    }
}
