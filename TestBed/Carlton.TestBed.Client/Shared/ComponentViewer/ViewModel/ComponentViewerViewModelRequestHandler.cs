﻿using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.ComponentViewer
{
    public class ComponentViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<ComponentViewerViewModelRequest, ComponentViewerViewModel>
    {
       
        public ComponentViewerViewModelRequestHandler(TestBedState state)
            :base(state)
        {
        }

        public override Task<ComponentViewerViewModel> Handle(ComponentViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComponentViewerViewModel
            {
                ComponentType = State.TestComponentType,
                ComponentViewModel = State.TestComponentViewModel,
                ComponentStatus = State.TestComponentStatus,
                IsCarltonComponent = State.IsTestComponentCarltonComponent
            });
        }
    }
}