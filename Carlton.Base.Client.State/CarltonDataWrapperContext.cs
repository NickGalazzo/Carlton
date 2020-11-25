using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State
{
    public class CarltonDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; private set; }
        public Func<object, Task> ComponentEventHandler { get; }

        public CarltonDataWrapperContext(
            TViewModel vm,
            Func<object, Task> componentEventHandler)
        {
            ViewModel = vm;
            ComponentEventHandler = componentEventHandler;
        }
    }
}
