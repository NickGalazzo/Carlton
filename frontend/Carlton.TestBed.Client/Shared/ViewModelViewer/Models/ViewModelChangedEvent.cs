using Carlton.Base.Client.State.Contracts;

namespace Carlton.TestBed.Client.Shared.ViewModelViewer.Models
{
    public class ViewModelChangedEvent : ICarltonComponentEvent
    {
        public string EventName { get; private set; }
        public object ViewModel { get; private set; }
        
        public ViewModelChangedEvent(object vm)
        {
            ViewModel = vm;
        }
    }
}
