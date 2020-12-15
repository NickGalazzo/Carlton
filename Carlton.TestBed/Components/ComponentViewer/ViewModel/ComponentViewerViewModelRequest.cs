using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record ComponentViewerViewModel(Type ComponentType, object ComponentViewModel, ComponentStatus ComponentStatus, bool IsCarltonComponent);
    
    public class ComponentViewerViewModelRequest : IRequest<ComponentViewerViewModel>
    {
    }

    public class ComponentViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<ComponentViewerViewModelRequest, ComponentViewerViewModel>
    {

        public ComponentViewerViewModelRequestHandler(TestBedState state)
            : base(state)
        {
        }

        public override Task<ComponentViewerViewModel> Handle(ComponentViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComponentViewerViewModel
            (
                State.TestComponentType,
                State.TestComponentViewModel,
                State.TestComponentStatus,
                State.IsTestComponentCarltonComponent
            ));
        }
    }
}
