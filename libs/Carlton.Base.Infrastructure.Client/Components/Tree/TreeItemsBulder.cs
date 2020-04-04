using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
{
    public class TreeItemsBuilder
    {
        private readonly List<(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)> _componentTestStates;

        public TreeItemsBuilder()
        {
            _componentTestStates = new List<(string, Type, object viewModel, bool IsCarltonComponent)>();
        }

        public TreeItemsBuilder AddTreeNode<T>(string nodeTitle, object viewModel)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), viewModel, true));
            return this;
        }

        public TreeItemsBuilder AddSimpleComponent<T>(string nodeTitle)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), new Dictionary<string, object>(), false));
            return this;
        }

        public TreeItemsBuilder AddSimpleComponent<T>(string nodeTitle, IDictionary<string, object> componentParams)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), componentParams, false));
            return this;
        }

        public IEnumerable<TreeItem> Build()
        {
            var treeItems = new List<TreeItem>();

            var statesGroupedByComponent = _componentTestStates.GroupBy(o => o.type);

            statesGroupedByComponent.ToList().ForEach(group =>
            {
                var children = new List<TreeItem>();
                var treeItem = TreeItem.CreateParentNode(group.Key.Name, children);
                
                group.ToList().ForEach(tup =>
                {
                 
                    children.Add(TreeItem.CreateChildNode(tup.nodeTitle, tup.type, tup.viewModel, tup.isCarltonComponent));
                });
                
                treeItems.Add(treeItem);
            });
            return treeItems;
        }
    }
}
