namespace Carlton.TestBed.Client.Shared.ViewModelViewer.Models
{
    public class ModelViewerModelChangedEvent
    {
        public object ComponentViewModel { get; private set; }
        
        public ModelViewerModelChangedEvent(object vm)
        {
            ComponentViewModel = vm;
        }
    }
}
