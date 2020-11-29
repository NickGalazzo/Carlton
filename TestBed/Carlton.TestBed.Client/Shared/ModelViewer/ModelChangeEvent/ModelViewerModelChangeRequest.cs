using Carlton.Base.Client.State;
using Carlton.TestBed.Client.Shared.ViewModelViewer.Models;

namespace Carlton.TestBed.Client.Shared.ModelViewer
{
    public class ModelViewerModelChangeRequest : ComponentEventRequestBase<ModelViewerModelChangedEvent>
    {
        public ModelViewerModelChangeRequest(object sender, ModelViewerModelChangedEvent evt) : base(sender, evt)
        {
        }
    }
}
