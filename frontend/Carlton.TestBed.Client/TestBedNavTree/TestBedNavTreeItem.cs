using System;
using System.Linq;
using System.Collections.Generic;

namespace Carlton.TestBed.TestBedNavTree
{
    public class TestBadNavTreeItem
    {
        public string DisplayName { get;private set; }
        public bool IsParentNode { get { return Children.Any(); } }

        //Parent Properties
        public IEnumerable<TestBadNavTreeItem> Children { get; set; }

        //Child Properties
        public Type Type { get; private set; }
        public object ViewModel { get; private set; }
        public bool IsCarltonComponent { get; private set; }


        private TestBadNavTreeItem(string displayName, IEnumerable<TestBadNavTreeItem> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private TestBadNavTreeItem(string displayName, Type type, object viewModel, bool isCarltonComponent)
        {
            DisplayName = displayName;
            Type = type;
            ViewModel = viewModel;
            IsCarltonComponent = isCarltonComponent;
            Children = new List<TestBadNavTreeItem>();
        }

        public static TestBadNavTreeItem CreateParentNode(string displayName, IEnumerable<TestBadNavTreeItem> children)
        {
            return new TestBadNavTreeItem(displayName, children);
        }

        public static TestBadNavTreeItem CreateChildNode(string displayName, Type type, object componentParams, bool isCarltonComponent)
        {
            return new TestBadNavTreeItem(displayName, type, componentParams, isCarltonComponent);
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
