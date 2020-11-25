using System;
using System.Collections.Generic;
using Carlton.Base.Client.State;
using Carlton.Base.Client.Status;
using Carlton.TestBed.Client.Shared.NavTree;
 
namespace Carlton.TestBed.Client.State
{
    public class TestBedState : ICarltonStateStore
    {
        public event Action<object, string> StateChanged;

        public IEnumerable<NavTreeItem> TreeItems { get; private set; }
        public NavTreeItem SelectedItem { get; private set; }
        public Type TestComponentType { get { return SelectedItem.Type; } }
        public bool IsTestComponentCarltonComponent { get; private set; }
        public ComponentStatus TestComponentStatus { get; private set; }
        public object TestComponentViewModel { get { return SelectedItem.ViewModel; } set { var x = 7; } }
        public IList<object> ComponentEvents { get; private set; }

        public TestBedState(IEnumerable<NavTreeItem> treeItems)
        {
            TreeItems = treeItems;
            SelectedItem = TreeItems.GetFirstSelectableTestState();
            ComponentEvents = new List<object>();
            TestComponentStatus = ComponentStatus.SYNCED;
        }
    }
}





