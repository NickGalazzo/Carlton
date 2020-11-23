using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client.Shared.NavTree.Requests
{
    public class NavTreeSelectNodeRequest : ICarltonComponentRequest<NavTreeViewModel>
    {
        public TestBedNavTreeItem SelectedItem { get; set; }
    }
}
