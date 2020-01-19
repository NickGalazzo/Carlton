using Carlton.Base.Infastructure.Client.Events;
using System;
using System.Threading.Tasks;

namespace Carlton.Base.Infastructure.Client.Components
{
    public class ComponentDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; }
        public Func<IComponentEvent<IComponentEventResult>, Task<IComponentEventResult>> ComponentEventHandler { get; }
        
        public ComponentDataWrapperContext(TViewModel viewModel, Func<IComponentEvent<IComponentEventResult>, Task<IComponentEventResult>> componentEventHandler)
        {
            ViewModel = viewModel;
            ComponentEventHandler = componentEventHandler;
        }
    }
}
