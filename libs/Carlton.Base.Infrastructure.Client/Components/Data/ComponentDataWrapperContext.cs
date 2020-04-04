using Carlton.Base.Client.Events;
using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.Data
{
    public class ComponentDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; }
        public Func<IComponentEvent, Task> ComponentEventHandler { get; }
        
        public ComponentDataWrapperContext(TViewModel viewModel, Func<IComponentEvent, Task> componentEventHandler)
        {
            ViewModel = viewModel;
            ComponentEventHandler = componentEventHandler;
        }
    }
}
