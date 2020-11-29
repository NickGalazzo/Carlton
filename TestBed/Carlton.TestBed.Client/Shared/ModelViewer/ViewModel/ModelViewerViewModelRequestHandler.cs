using System;
using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.Client.Shared.ViewModelViewer;
using Carlton.TestBed.Client.State;


namespace Carlton.TestBed.Client.Shared.ModelViewer
{
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
