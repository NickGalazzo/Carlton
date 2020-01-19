using Carlton.Base.Infastructure.Client.Events;
using System;

namespace Carlton.Base.Infastructure.Client.Components
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
