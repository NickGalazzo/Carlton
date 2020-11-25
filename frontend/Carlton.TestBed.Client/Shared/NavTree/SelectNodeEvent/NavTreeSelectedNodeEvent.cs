namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectedNodeEvent 
    {
        public NavTreeItem SelectedItem { get; }

        public NavTreeSelectedNodeEvent(NavTreeItem selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
