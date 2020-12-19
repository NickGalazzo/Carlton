using System.Collections.Generic;
using Carlton.Base.Client.Components;

namespace Carlton.TestBed.Components
{
    public record NavTreeViewModel
    (
        IEnumerable<TreeItem<NavTreeItemModel>> TreeItems,
        TreeItem<NavTreeItemModel> SelectedNode,
        IEnumerable<TreeItem<NavTreeItemModel>> ExpandedNodes
    );
}
