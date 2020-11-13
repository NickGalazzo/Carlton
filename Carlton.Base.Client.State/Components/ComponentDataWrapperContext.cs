using Carlton.Base.Client.State.Contracts;
using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State.Components
{
    public class ComponentDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; private set; }
        public Func<IComponentEvent<TViewModel>, Task> ComponentEventHandler { get; }

        public ComponentDataWrapperContext(TViewModel vm,
            Func<IComponentEvent<TViewModel>, Task> componentEventHandler)
        {
            ViewModel = vm;
            ComponentEventHandler = componentEventHandler;
        }

        public void ReplaceViewModel(TViewModel vm)
        {
            ViewModel = vm;
        }
    }
}
