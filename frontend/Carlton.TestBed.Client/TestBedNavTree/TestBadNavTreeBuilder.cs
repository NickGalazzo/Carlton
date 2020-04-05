﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace Carlton.TestBed.TestBedNavTree
{
    public class TestBadNavTreeBuilder
    {
        private readonly List<(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)> _componentTestStates;

        public TestBadNavTreeBuilder()
        {
            _componentTestStates = new List<(string, Type, object viewModel, bool IsCarltonComponent)>();
        }

        public TestBadNavTreeBuilder AddTreeNode<T>(string nodeTitle, object viewModel)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), viewModel, true));
            return this;
        }

        public TestBadNavTreeBuilder AddSimpleComponent<T>(string nodeTitle)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), new Dictionary<string, object>(), false));
            return this;
        }

        public TestBadNavTreeBuilder AddSimpleComponent<T>(string nodeTitle, IDictionary<string, object> componentParams)
        {
            _componentTestStates.Add((nodeTitle, typeof(T), componentParams, false));
            return this;
        }

        public IEnumerable<TestBadNavTreeItem> Build()
        {
            return GroupBySmartAndDumb(_componentTestStates);
        }

        private static IEnumerable<TestBadNavTreeItem> GroupBySmartAndDumb(List<(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)> states)
        {
            var treeItems = new List<TestBadNavTreeItem>();

            var statesGroupedBySmartAndDumb = states.GroupBy(o => o.isCarltonComponent);

            statesGroupedBySmartAndDumb.ToList().ForEach(group =>
            {
                IEnumerable<TestBadNavTreeItem> children = new List<TestBadNavTreeItem>();
                children = GroupByComponent(group.ToList());

                var treeItem = TestBadNavTreeItem.CreateParentNode(group.Key ? "Carlton Components" : "Simple Components", children);


                treeItems.Add(treeItem);
            });

            return treeItems;
        }

        public static IEnumerable<TestBadNavTreeItem> GroupByComponent(List<(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)> states)
        {
            var treeItems = new List<TestBadNavTreeItem>();
            var statesGroupedByComponent = states.GroupBy(o => o.type);

            statesGroupedByComponent.ToList().ForEach(group =>
            {
                var children = new List<TestBadNavTreeItem>();
                var treeItem = TestBadNavTreeItem.CreateParentNode(group.Key.Name, children);

                group.ToList().ForEach(tup =>
                {
                    children.Add(TestBadNavTreeItem.CreateChildNode(tup.nodeTitle, tup.type, tup.viewModel, tup.isCarltonComponent));
                });

                treeItems.Add(treeItem);
            });

            return treeItems;
        }
    }
}