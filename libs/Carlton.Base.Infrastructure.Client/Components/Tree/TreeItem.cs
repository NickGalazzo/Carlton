using System;
using System.Linq;
using System.Collections.Generic;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
{
    public class TreeItem
    {
        public string DisplayName { get;private set; }
        public Type Type { get; private set; }
        public object ViewModel { get; set; }

        public IEnumerable<TreeItem> Children { get; set; }
        public bool IsParentNode { get { return Children.Any(); } }
        public bool IsCarltonComponent { get; private set; }

        private TreeItem(string displayName, IEnumerable<TreeItem> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private TreeItem(string displayName, Type type, object viewModel, bool isCarltonComponent)
        {
            DisplayName = displayName;
            Type = type;
            ViewModel = viewModel;
            IsCarltonComponent = isCarltonComponent;
            Children = new List<TreeItem>();
        }

        public static TreeItem CreateParentNode(string displayName, IEnumerable<TreeItem> children)
        {
            return new TreeItem(displayName, children);
        }

        public static TreeItem CreateChildNode(string displayName, Type type, object componentParams, bool isCarltonComponent)
        {
            return new TreeItem(displayName, type, componentParams, isCarltonComponent);
        }

        //public static TreeItem CreateSimpleChildNode(string displayName, Type type, IDictionary<string, object> componentParams)
        //{
        //    return new TreeItem(displayName, type, componentParams, false);
        //}

        //public static TreeItem CreateCarltonChildNode(string displayName, Type type, object viewModel)
        //{
        //    return new TreeItem(displayName, type, viewModel, true);
        //}
    }
}
