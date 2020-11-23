using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectNodeRequest : ICarltonComponentRequest<NavTreeViewModel>
    {
        public NavTreeItem SelectedItem { get; set; }
    }
}
