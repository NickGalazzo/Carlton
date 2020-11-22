using System;
using System.Linq;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree.Models
{
    public class TestBedNavTreeItem
    {
        public string DisplayName { get;private set; }
        public bool IsParentNode { get { return Children.Any(); } }

        //Parent Properties
        public IEnumerable<TestBedNavTreeItem> Children { get; set; }

        //Child Properties
        public Type Type { get; private set; }
        public object ViewModel { get; private set; }
        public bool IsCarltonComponent { get; private set; }


        private TestBedNavTreeItem(string displayName, IEnumerable<TestBedNavTreeItem> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private TestBedNavTreeItem(string displayName, Type type, object viewModel, bool isCarltonComponent)
        {
            DisplayName = displayName;
            Type = type;
            ViewModel = viewModel;
            IsCarltonComponent = isCarltonComponent;
            Children = new List<TestBedNavTreeItem>();
        }

        public static TestBedNavTreeItem CreateParentNode(string displayName, IEnumerable<TestBedNavTreeItem> children)
        {
            return new TestBedNavTreeItem(displayName, children);
        }

        public static TestBedNavTreeItem CreateLeafNode(string displayName, Type type, object componentParams, bool isCarltonComponent)
        {
            return new TestBedNavTreeItem(displayName, type, componentParams, isCarltonComponent);
        }
    }
}
