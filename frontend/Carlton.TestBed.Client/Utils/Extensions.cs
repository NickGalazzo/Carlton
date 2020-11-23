using System.Collections.Generic;
using System.Linq;
using Carlton.TestBed.Client.Shared.NavTree;

namespace Carlton.TestBed.Client
{
    public static class NavTreeItemExtensions
    {
        public static NavTreeItem GetFirstSelectableTestState(this IEnumerable<NavTreeItem> treeItems)
        {
            var item = treeItems.First();

            while(item.Children.Any())
            {
                item = item.Children.First();
            }

            return item;
        }
    }
}
