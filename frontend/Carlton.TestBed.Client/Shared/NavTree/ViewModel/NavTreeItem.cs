using System;
using System.Linq;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeItem
    {
        public string DisplayName { get;private set; }
        public bool IsParentNode { get { return Children.Any(); } }

        //Parent Properties
        public IEnumerable<NavTreeItem> Children { get; set; }

        //Child Properties
        public Type Type { get; private set; }
        public object ViewModel { get; private set; }
        public bool IsCarltonComponent { get; private set; }


        private NavTreeItem(string displayName, IEnumerable<NavTreeItem> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private NavTreeItem(string displayName, Type type, object viewModel, bool isCarltonComponent)
        {
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

        public static NavTreeItem CreateLeafNode(string displayName, Type type, object componentParams, bool isCarltonComponent)
        {
            return new NavTreeItem(displayName, type, componentParams, isCarltonComponent);
        }
    }
}
