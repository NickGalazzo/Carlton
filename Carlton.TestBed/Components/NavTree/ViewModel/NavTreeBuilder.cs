using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.TestBed.Components
{
    public class NavTreeBuilder
    {
        private readonly List<InternalStateItem> _internalState;

        public NavTreeBuilder()
        {
            _internalState = new List<InternalStateItem>();
        }

        public void AddCarltonComponent<T>(string nodeTitle, object viewModel)
        {
            _internalState.Add(new InternalStateItem(nodeTitle, typeof(T), viewModel, true));
        }

        public void AddComponent<T>(string nodeTitle)
        {
            _internalState.Add(new InternalStateItem(nodeTitle, typeof(T), new Dictionary<string, object>(), false));
        }

        public void AddComponent<T>(string nodeTitle, IDictionary<string, object> componentParams)
        {
            _internalState.Add(new InternalStateItem(nodeTitle, typeof(T), componentParams, false));;
        }

        public IEnumerable<NavTreeItem> Build()
        {
            var leafIndex = 1;
            var treeRootNode = NavTreeItem.CreateParentNode("root", Array.Empty<NavTreeItem>());

            foreach(var state in _internalState)
            {
                AddNavTreeItem(state, treeRootNode);
            }

            return treeRootNode.Children;


            void AddNavTreeItem(InternalStateItem state, NavTreeItem parentNode)
            {
                var nodes = state.NodeTitle.Split('/');
                var currentTitle = nodes[0];
                var currentNode = parentNode.Children.SingleOrDefault(o => o.DisplayName == currentTitle);
                var currentNodeExists = currentNode != null;
                var isLeafNode = nodes.Length == 1;

                //Leaf Node
                if(isLeafNode)
                {
                    var leafChild = NavTreeItem.CreateLeafNode(leafIndex, currentTitle, state.Type, state.ViewModel, state.IsCarltonComponent);
                    parentNode.Children = parentNode.Children.Append(leafChild);
                    leafIndex++;
                    return;
                }

                //Parent Does Not Exist
                if(!currentNodeExists)
                {
                    var newNode = NavTreeItem.CreateParentNode(currentTitle, Array.Empty<NavTreeItem>());
                    parentNode.Children = parentNode.Children.Append(newNode);
                    currentNode = newNode;
                }

                //Move to the Next Node
                state.PopCurrentFromNodeTitle();
                AddNavTreeItem(state, currentNode);
            };
        }

        private record InternalStateItem
        {
            public string NodeTitle { get; private set; }
            public Type Type { get; init; }
            public object ViewModel { get; init; }
            public bool IsCarltonComponent { get; init; }
            
            public InternalStateItem(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)
                => (NodeTitle, Type, ViewModel, IsCarltonComponent) = (nodeTitle, type, viewModel, isCarltonComponent);
            
            public void PopCurrentFromNodeTitle() 
                => NodeTitle = string.Join('/', NodeTitle.Split('/').Skip(1));  
        }
    }
}
