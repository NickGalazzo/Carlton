using Carlton.TestBed.TestBedNavTree;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.TestBed.Client.Utils
{
    public static class Extensions
    {
        public static TestBedNavTreeItem GetFirstSelectableTestState(this IEnumerable<TestBedNavTreeItem> treeItems)
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
