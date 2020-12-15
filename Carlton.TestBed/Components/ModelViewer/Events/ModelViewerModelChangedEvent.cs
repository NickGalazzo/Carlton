using Carlton.Base.Client.State;
using Carlton.TestBed.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Components
{
    public record ModelViewerModelChangedEvent(object ComponentViewModel);
    public class ModelViewerModelChangeRequest : ComponentEventRequestBase<ModelViewerModelChangedEvent>
    {
        public ModelViewerModelChangeRequest(object sender, ModelViewerModelChangedEvent evt) : base(sender, evt)
        {
        }
    }
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
