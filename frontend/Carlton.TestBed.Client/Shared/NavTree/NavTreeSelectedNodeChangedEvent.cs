using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectedNodeChangedEvent : ICarltonComponentEvent
    {
        public TestBedNavTreeItem SelectedItem { get; }
        public string EventName => "";

        public NavTreeSelectedNodeChangedEvent(TestBedNavTreeItem selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
