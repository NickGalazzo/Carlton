using System.Collections.Generic;
using System.Linq;
using Carlton.Base.Client.Components;

namespace Carlton.TestBed
{
    public static class TreeItemEnumerableExtensions
    {
        public static TreeItem<T> GetFirstSelectableTestState<T>(this IEnumerable<TreeItem<T>> treeItems)
        {
            var item = treeItems.First();

            while(item.Children.Any())
            {
                item = item.Children.First();
            }

            return item;
        }

        public static TreeItem<T> GetLeafById<T>(this IEnumerable<TreeItem<T>> treeItems, int leafId)
        {
            foreach(var item in treeItems)
            {
                if(item.LeafId == leafId)
                    return item;

                var children = item.Children.Where(_ => _.IsParentNode).ToList();
                var leaf = item.Children.Where(_ => !_.IsParentNode)
                                        .FirstOrDefault(_ => _.LeafId == leafId);
                var foundLeaf = leaf != null;

                if(foundLeaf)
                {
                    return leaf;
                }
                else
                {
                    leaf = item.Children.Where(_ => _.IsParentNode).GetLeafById(leafId);
                    if(leaf != null)
                        return leaf;
                }
            }

            return null;
        }
    }
}


