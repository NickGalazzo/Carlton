namespace Carlton.TestBed.Client.Shared.ViewModelViewer.Models
{
    public class ModelViewerModelChangedEvent
    {
        public string EventName { get; private set; }
        public object ViewModel { get; private set; }
        
        public ModelViewerModelChangedEvent(object vm)
        {
            ViewModel = vm;
        }
    }
}
