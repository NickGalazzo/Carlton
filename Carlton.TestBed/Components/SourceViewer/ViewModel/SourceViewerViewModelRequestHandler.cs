using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public class SourceViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<SourceViewerViewModelRequest, SourceViewerViewModel>
    {
        public SourceViewerViewModelRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<SourceViewerViewModel> Handle(SourceViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SourceViewerViewModel(State.TestComponentType));
        }
    }
}
