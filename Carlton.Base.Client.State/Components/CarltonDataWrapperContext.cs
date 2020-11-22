using Carlton.Base.Client.State.Contracts;
using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State.Components
{
    public class CarltonDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; private set; }
        public Func<ICarltonComponentEvent, Task> ComponentEventHandler { get; }

        public CarltonDataWrapperContext(
            TViewModel vm,
            Func<ICarltonComponentEvent, Task> componentEventHandler)
        {
            ViewModel = vm;
            ComponentEventHandler = componentEventHandler;
        }
    }
}
