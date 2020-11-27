using System;
using System.Linq;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public record NavTreeItem
    {
        public string DisplayName { get; init; }
        public bool IsParentNode { get { return Children.Any(); } }

        //Parent Properties
        public IEnumerable<NavTreeItem> Children { get; set; }

        //Child Properties
        public int LeafId { get; init; }
        public Type Type { get; init; }
        public object ViewModel { get; init; }
        public bool IsCarltonComponent { get; init; }


        private NavTreeItem(string displayName, IEnumerable<NavTreeItem> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private NavTreeItem(int leafId, string displayName, Type type, object viewModel, bool isCarltonComponent)
        {
            LeafId = leafId;
            DisplayName = displayName;
            Type = type;
            ViewModel = viewModel;
            IsCarltonComponent = isCarltonComponent;
            Children = new List<NavTreeItem>();
        }

        public static NavTreeItem CreateParentNode(string displayName, IEnumerable<NavTreeItem> children)
        {
            return new NavTreeItem(displayName, children);
        }

        public static NavTreeItem CreateLeafNode(int leafId, string displayName, Type type, object componentParams, bool isCarltonComponent)
        {
            return new NavTreeItem(leafId, displayName, type, componentParams, isCarltonComponent);
        }
    }
}
