using System;
using System.Threading.Tasks;
using Carlton.Base.Client.Status;
using Carlton.TestBed.Client.State;
using MediatR;

namespace Carlton.TestBed.Client.Shared.ComponentViewer
{
    public class ComponentViewerViewModel
    {
        public Type ComponentType { get; set; }
        public object ComponentViewModel { get; set; }
        public ComponentStatus ComponentStatus { get; set; }
        public bool IsCarltonComponent { get; set; }
    }
    public class ComponentViewerViewModelRequest : IRequest<ComponentViewerViewModel>
    {
    }

    public class ComponentViewerViewModelHandler : TestBedRequestHandlerViewModelBase<ComponentViewerViewModelRequest, ComponentViewerViewModel>
    {

        public ComponentViewerViewModelRequestHandler(TestBedState state)
            : base(state)
        {
        }

        public override Task<ComponentViewerViewModel> Handle(ComponentViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComponentViewerViewModel
            {
                ComponentType = State.TestComponentType,
                ComponentViewModel = State.TestComponentViewModel,
                ComponentStatus = State.TestComponentStatus,
                IsCarltonComponent = true //_state.IsTestComponentCarltonComponent
                //SelectedNode = _state.TreeItems
            });
        }
    }

}
