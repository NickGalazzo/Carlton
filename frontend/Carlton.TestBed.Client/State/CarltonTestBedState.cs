using Carlton.Base.Client.State.Contracts;
using Carlton.Base.Client.Status;
using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Utils;
using System;
using System.Collections.Generic;
 
namespace Carlton.TestBed.Client.State
{
    public class CarltonTestBedState : ICarltonStateStore
    {
        public event Action<object, string> StateChanged;

        public IEnumerable<TestBedNavTreeItem> TreeItems { get; private set; }
        public TestBedNavTreeItem SelectedItem { get; private set; }
        public Type TestComponentType { get { return SelectedItem.Type; } }
        public bool IsTestComponentCarltonComponent { get; private set; }
        public ComponentStatus TestComponentStatus { get; private set; }
        public object TestComponentViewModel { get { return SelectedItem.ViewModel; } }
        public IList<object> ComponentEvents { get; private set; }

        public CarltonTestBedState(IEnumerable<TestBedNavTreeItem> treeItems)
        {
            TreeItems = treeItems;
            SelectedItem = TreeItems.GetFirstSelectableTestState();
        }
    }
}





