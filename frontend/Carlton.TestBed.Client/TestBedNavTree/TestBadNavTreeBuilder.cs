using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.TestBedNavTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.TestBed.TestBedNavTree
{
    public class TestBadNavTreeBuilder
    {
        private readonly List<TestBedState> _componentTestStates;

        public TestBadNavTreeBuilder()
        {
            _componentTestStates = new List<TestBedState>();
        }

        public TestBadNavTreeBuilder AddCarltonComponent<T>(string nodeTitle, object viewModel)
        {
            _componentTestStates.Add(new TestBedState(nodeTitle, typeof(T), viewModel, true));
            return this;
        }

        public TestBadNavTreeBuilder AddComponent<T>(string nodeTitle)
        {
            _componentTestStates.Add(new TestBedState(nodeTitle, typeof(T), new Dictionary<string, object>(), false));
            return this;
        }

        public TestBadNavTreeBuilder AddComponent<T>(string nodeTitle, IDictionary<string, object> componentParams)
        {
            _componentTestStates.Add(new TestBedState(nodeTitle, typeof(T), componentParams, false));
            return this;
        }

        public IEnumerable<TestBedNavTreeItem> Build()
        {
            var treeRootNode = TestBedNavTreeItem.CreateParentNode("root", Array.Empty<TestBedNavTreeItem>());

            foreach(var state in _componentTestStates)
            {
                AddNavTreeItem(state, treeRootNode);
            }

            return treeRootNode.Children;


            void AddNavTreeItem(TestBedState state, TestBedNavTreeItem parentNode)
            {
                var nodes = state.NodeTitle.Split('/');
                var currentTitle = nodes[0];
                var currentNode = parentNode.Children.SingleOrDefault(o => o.DisplayName == currentTitle);
                var currentNodeExists = currentNode != null;
                var isLeafNode = nodes.Length == 1;
              
                //Leaf Node
                if(isLeafNode)
                {
                    var leafChild = TestBedNavTreeItem.CreateLeafNode(currentTitle, state.Type, state.ViewModel, state.IsCarltonComponent);
                    parentNode.Children = parentNode.Children.Append(leafChild);
                    return;
                }
                
                //Parent Does Not Exist
                if(!currentNodeExists)
                {
                    var newNode = TestBedNavTreeItem.CreateParentNode(currentTitle, Array.Empty<TestBedNavTreeItem>());
                    parentNode.Children = parentNode.Children.Append(newNode);
                    currentNode = newNode;
                }

                //Move to the Next Node
                state.PopCurrentFromNodeTitle();
                AddNavTreeItem(state, currentNode);  
            };
        }
    }
}
