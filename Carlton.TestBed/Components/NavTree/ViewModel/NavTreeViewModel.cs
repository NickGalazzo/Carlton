using System.Collections.Generic;
using System.Linq;

namespace Carlton.TestBed.Components
{
    public record NavTreeViewModel
    {
        public IEnumerable<NavTreeItem> TreeItems { get; init; }
        public NavTreeItem SelectedNode { get; init; }
        public IEnumerable<NavTreeItem> ExpandedNodes { get; init; }

       
    }
}
