using System.Collections.Generic;

namespace Carlton.TestBed.Components
{
    public record NavTreeViewModel
    (
        IEnumerable<NavTreeItem> TreeItems,
        NavTreeItem SelectedNode,
        IEnumerable<NavTreeItem> ExpandedNodes
    );
}
