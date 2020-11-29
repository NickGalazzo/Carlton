using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public record NavTreeViewModel(IEnumerable<NavTreeItem> TreeItems, 
         NavTreeItem SelectedNode, 
         IEnumerable<NavTreeItem> ExpandedNodes);
    
}
