using Carlton.Base.Client.State.Contracts;
using System;
using System.Linq;

namespace Carlton.TestBed.Client.TestBedNavTree
{
    internal class TestBedState 
    {
        public string NodeTitle { get; private set; }
        public Type Type { get; private set; }
        public object ViewModel { get; private set; }
        public bool IsCarltonComponent { get; private set; }

        public TestBedState(string nodeTitle, Type type, object viewModel, bool isCarltonComponent)
        {
            NodeTitle = nodeTitle;
            Type = type;
            ViewModel = viewModel;
            IsCarltonComponent = isCarltonComponent;
        }

        public void PopCurrentFromNodeTitle()
        {
            NodeTitle = string.Join('/', NodeTitle.Split('/').Skip(1));
        }
    }
}
