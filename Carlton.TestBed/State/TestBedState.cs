using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carlton.Base.Client.Components;
using Carlton.Base.Client.State;
using Carlton.TestBed.Components;


namespace Carlton.TestBed.State
{
    public class TestBedState : ICarltonStateStore
    {
        public static string SELECTED_ITEM = "SelectedItem";
        public static string VIEW_MODEL_CHANGED = "ViewModelChanged";
        public static string STATUS_CHANGED = "StatusChanged";
        public static string COMPONENT_EVENT_ADDED = "ComponentEventAdded";
        public static string COMPONENT_EVENTS_CLEARED = "COMPONENT_EVENTS_CLEARED";

        public event Func<object, string, Task> StateChanged;

        private readonly IList<object> _componentEvents;

        public IEnumerable<TreeItem<NavTreeItemModel>> TreeItems { get; init; }
        public TreeItem<NavTreeItemModel> SelectedItem { get; private set; }
        public Type TestComponentType { get { return SelectedItem.Type; } }
        public bool IsTestComponentCarltonComponent { get { return SelectedItem.LeafNodeObj.IsCarltonComponent; } }
        public object TestComponentViewModel { get; private set; }
        public ComponentStatus TestComponentStatus { get; private set; }
        public IEnumerable<object> ComponentEvents { get { return _componentEvents; } }

        public TestBedState(NavTreeViewModel navTreeVM)
        {
            TreeItems = navTreeVM.TreeItems;
            SelectedItem = navTreeVM.SelectedNode;
            TestComponentViewModel = navTreeVM.SelectedNode.LeafNodeObj.ViewModel;
            _componentEvents = new List<object>();
            TestComponentStatus = ComponentStatus.SYNCED;
        }

        public async Task AddTestComponentEvents(object sender, object componentEvent)
        {
            _componentEvents.Add(componentEvent);
            await StateChanged.Invoke(sender, COMPONENT_EVENT_ADDED).ConfigureAwait(false);
        }

        public async Task ClearComponentEvents(object sender)
        {
            _componentEvents.Clear();
            await StateChanged.Invoke(sender, COMPONENT_EVENTS_CLEARED).ConfigureAwait(false);
        }

        public async Task UpdateTestComponentViewModel(object sender, object vm)
        {
            TestComponentViewModel = vm;
            await StateChanged.Invoke(sender, VIEW_MODEL_CHANGED).ConfigureAwait(false);
        }

        public async Task UpdateComponentStatus(object sender, ComponentStatus status)
        {
            TestComponentStatus = status;
            await StateChanged.Invoke(sender, STATUS_CHANGED).ConfigureAwait(false);
        }

        public async Task UpdateSelectedItemId(object sender, int id)
        {
            TreeItems.ToList().ForEach(_ => System.Console.WriteLine(_.LeafId));
            SelectedItem = TreeItems.GetLeafById(id);
            TestComponentViewModel = SelectedItem.LeafNodeObj.ViewModel;
            await StateChanged.Invoke(sender, SELECTED_ITEM).ConfigureAwait(false);
        }
    }
}





