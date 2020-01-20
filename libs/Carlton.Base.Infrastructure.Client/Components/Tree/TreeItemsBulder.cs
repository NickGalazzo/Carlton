using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
{
    public class TreeItemsBuilder
    {
        private readonly List<(Type type, string nodeTitle)> _componentTestStates;

        public TreeItemsBuilder()
        {
            _componentTestStates = new List<(Type, string)>();
        }

        public TreeItemsBuilder AddTreeNode<T>(string nodeTitle)
        {
            _componentTestStates.Add((typeof(T), nodeTitle));
            return this;
        }

        public IEnumerable<TreeItem> Build()
        {
            var treeItems = new List<TreeItem>();

            var statesGroupedByComponent = _componentTestStates.GroupBy(o => o.type);

            statesGroupedByComponent.ToList().ForEach(group =>
            {
                var children = new List<TreeItem>();
                var treeItem = new TreeItem { Text = group.Key.Name, Children = children };

                group.ToList().ForEach(tup => children.Add(new TreeItem { Text = tup.nodeTitle }));
                treeItems.Add(treeItem);

            });
            return treeItems;
        }
    }
}
