﻿using Carlton.TestBed.Client.Shared.ComponentViewer.Models;
using Carlton.TestBed.Client.Shared.ComponentViewer.Requests;
using Carlton.TestBed.Client.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.ComponentViewer.Handler
{
    public class ComponentViewerViewModelRequestHandler : GetViewModelRequestHandlerBase<ComponentViewerViewModelRequest, ComponentViewerViewModel>
    {
       
        public ComponentViewerViewModelRequestHandler(CarltonTestBedState state)
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
                IsCarltonComponent = true //_state.IsTestComponentCarltonComponent
                //SelectedNode = _state.TreeItems
            });
        }
    }
}
