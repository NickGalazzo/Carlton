using System.Collections.Generic;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeViewModel
    {
        public IEnumerable<TestBedNavTreeItem> TreeItems { get; set; }
        public TestBedNavTreeItem SelectedNode { get; set; }
        public IEnumerable<TestBedNavTreeItem> ExpandedNodes { get; set; }
    }
}
