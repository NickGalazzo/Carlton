using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.ModelViewer
{
    public class ModelViewerModelChangeRequestHandler : TestBedEventRequestHandlerBase<ModelViewerModelChangeRequest>
    {
        public ModelViewerModelChangeRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<Unit> Handle(ModelViewerModelChangeRequest request, CancellationToken cancellationToken)
        {
            State.TestComponentViewModel = request.ComponentEvent.ComponentViewModel;
            return Task.FromResult(Unit.Value);
        }
    }
}
