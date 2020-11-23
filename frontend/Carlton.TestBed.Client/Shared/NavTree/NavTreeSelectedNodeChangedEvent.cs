using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectedNodeChangedEvent : ICarltonComponentEvent
    {
        public NavTreeItem SelectedItem { get; }
        public string EventName => "";

        public NavTreeSelectedNodeChangedEvent(NavTreeItem selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
