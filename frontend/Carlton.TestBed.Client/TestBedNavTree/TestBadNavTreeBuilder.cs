using System;
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

        public TestBadNavTreeBuilder AddCarltonComponent<T>(string nodeTitle, object viewModel)
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

        public IEnumerable<TestBedNavTreeItem> Build(bool showSimpleComponents = false)
        {
            if(showSimpleComponents)
                return GroupBySmartAndDumb(_componentTestStates);
            else
            {
                _componentTestStates.RemoveAll(o => !o.isCarltonComponent);
                return GroupByComponent(_componentTestStates);
            }
        }

        private static IEnumerable<TestBedNavTreeItem> GroupBySmartAndDumb(List<(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)> states)
        {
            var treeItems = new List<TestBedNavTreeItem>();

            var statesGroupedBySmartAndDumb = states.GroupBy(o => o.isCarltonComponent);

            statesGroupedBySmartAndDumb.ToList().ForEach(group =>
            {
                IEnumerable<TestBedNavTreeItem> children = new List<TestBedNavTreeItem>();
                children = GroupByComponent(group.ToList());

                var treeItem = TestBedNavTreeItem.CreateParentNode(group.Key ? "Carlton Components" : "Simple Components", children);


                treeItems.Add(treeItem);
            });

            return treeItems;
        }

        public static IEnumerable<TestBedNavTreeItem> GroupByComponent(List<(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)> states)
        {
            var treeItems = new List<TestBedNavTreeItem>();
            var statesGroupedByComponent = states.GroupBy(o => o.type);

            statesGroupedByComponent.ToList().ForEach(group =>
            {
                var children = new List<TestBedNavTreeItem>();
                var treeItem = TestBedNavTreeItem.CreateParentNode(group.Key.Name, children);

                group.ToList().ForEach(tup =>
                {
                    children.Add(TestBedNavTreeItem.CreateChildNode(tup.nodeTitle, tup.type, tup.viewModel, tup.isCarltonComponent));
                });

                treeItems.Add(treeItem);
            });

            return treeItems;
        }
    }
}
