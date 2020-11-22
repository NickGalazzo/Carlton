using Carlton.Base.Client.State.Contracts;

namespace Carlton.TestBed.Client.Shared.ViewModelViewer.Models
{
    public class ViewModelChangedEvent : ICarltonComponentEvent
    {
        public string EventName { get { return TestBedRequestMapper.VIEW_MODEL_CHANGED_EVENT; } }
        public object ViewModel { get; private set; }
        
        public ViewModelChangedEvent(object vm)
        {
            ViewModel = vm;
        }
    }
}
