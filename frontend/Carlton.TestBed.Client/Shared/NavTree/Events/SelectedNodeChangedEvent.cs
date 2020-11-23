using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client.Shared.NavTree.Events
{
    public class SelectedNodeChangedEvent : ICarltonComponentEvent
    {
        public TestBedNavTreeItem SelectedItem { get; }
        public string EventName => "";

        public SelectedNodeChangedEvent(TestBedNavTreeItem selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
