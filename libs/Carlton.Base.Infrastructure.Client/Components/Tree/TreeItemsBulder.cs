using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
{
    public class TreeItemsBuilder
    {
        private readonly List<(string nodeTitle, Type type, object viewModel)> _componentTestStates;

        public TreeItemsBuilder()
        {
            _componentTestStates = new List<(string, Type, object viewModel)>();
        }

        public TreeItemsBuilder AddTreeNode<T>(string nodeTitle, object viewModel)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), viewModel));
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
                    children.Add(TreeItem.CreateChildNode(tup.nodeTitle, tup.type, tup.viewModel));
                    System.Console.WriteLine(tup.type);
                });
                
                treeItems.Add(treeItem);
             //   Console.WriteLine(group.FirstOrDefault().nodeTitle);
              //  Console.WriteLine(children.FirstOrDefault()?.DisplayName);

            });
            return treeItems;
        }
    }
}
