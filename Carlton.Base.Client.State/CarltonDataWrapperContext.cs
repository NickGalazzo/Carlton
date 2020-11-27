using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State
{
    public class CarltonDataWrapperContext<TViewModel>
    {
        public TViewModel ViewModel { get; set; }
        public Func<object, Task> OnComponentEvent { get; init; }

        public CarltonDataWrapperContext(
            TViewModel vm,
            Func<object, Task> onComponentEvent)
        {
            ViewModel = vm;
            OnComponentEvent = onComponentEvent;
        }
    }
}
