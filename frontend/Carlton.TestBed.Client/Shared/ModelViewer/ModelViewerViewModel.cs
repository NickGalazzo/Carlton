namespace Carlton.TestBed.Client.Shared.ModelViewer
{
    public class ModelViewerViewModel 
    {
        public object ViewModel { get; private set; }
        public ModelViewerViewModel(object vm)
        {
            ViewModel = vm;
        }
    }
}
