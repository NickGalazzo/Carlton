using Carlton.Base.Data;
using Carlton.Client.Base.Events;
using System;

namespace Carlton.Client.Base.Components
{
    public class ComponentDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; }
        public Action<IComponentEvent<IComponentEventResult>> ComponentEventHandler { get; }
        
        public ComponentDataWrapperContext(TViewModel viewModel, Action<IComponentEvent<IComponentEventResult>> componentEventHandler)
        {
            ViewModel = viewModel;
            ComponentEventHandler = componentEventHandler;
        }
    }
}
