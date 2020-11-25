namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectedNodeChangedEvent 
    {
        public NavTreeItem SelectedItem { get; }

        public NavTreeSelectedNodeChangedEvent(NavTreeItem selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
