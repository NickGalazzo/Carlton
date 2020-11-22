using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree.Models
{
    public class TestBedNavTreeViewModel
    {
        public IEnumerable<TestBedNavTreeItem> TreeItems { get; set; }
        public TestBedNavTreeItem SelectedNode { get; set; }
        public IEnumerable<TestBedNavTreeItem> ExpandedNodes { get; set; }
    }
}
