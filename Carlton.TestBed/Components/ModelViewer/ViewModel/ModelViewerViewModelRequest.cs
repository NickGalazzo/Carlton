using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record ModelViewerViewModel(object TestComponentViewModel);

    public class ModelViewerViewModelRequest : IRequest<ModelViewerViewModel>
    {
    }

    public class ModelViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<ModelViewerViewModelRequest, ModelViewerViewModel>
    {
        public ModelViewerViewModelRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<ModelViewerViewModel> Handle(ModelViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ModelViewerViewModel(State.TestComponentViewModel));
        }
    }
}
