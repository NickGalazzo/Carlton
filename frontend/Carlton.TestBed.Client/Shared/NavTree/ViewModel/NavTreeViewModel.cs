using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeViewModel
    {
        public IEnumerable<NavTreeItem> TreeItems { get; set; }
        public NavTreeItem SelectedNode { get; set; }
        public IEnumerable<NavTreeItem> ExpandedNodes { get; set; }
    }
}
