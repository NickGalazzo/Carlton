using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carlton.Base.Client.State;
using Carlton.Base.Client.Status;
using Carlton.TestBed.Client.Shared.NavTree;


namespace Carlton.TestBed.Client.State
{
    public class TestBedState : ICarltonStateStore
    {
        public static string SELECTED_ITEM = "SelectedItem";
        public static string VIEW_MODEL_CHANGED = "ViewModelChanged";
        public static string STATUS_CHANGED = "StatusChanged";

        public event Func<object, string, Task> StateChanged;

        private Dictionary<string, object> _defaultViewModels = new();
        public IEnumerable<NavTreeItem> TreeItems { get; init; }
        public NavTreeItem SelectedItem { get; private set; }
        public Type TestComponentType { get { return SelectedItem.Type; } }
        public bool IsTestComponentCarltonComponent { get { return SelectedItem.IsCarltonComponent; } }
        public object TestComponentViewModel { get; private set; }
        public ComponentStatus TestComponentStatus { get; private set; }
        public IList<object> ComponentEvents { get; private set; }

        public TestBedState(IEnumerable<NavTreeItem> treeItems)
        {
            TreeItems = treeItems;
            SelectedItem = TreeItems.GetFirstSelectableTestState();
            TestComponentViewModel = SelectedItem.ViewModel;
            ComponentEvents = new List<object>();
            TestComponentStatus = ComponentStatus.SYNCED;
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
            Console.WriteLine($"count: {TreeItems.ToList().Where(_ => !_.IsParentNode).Count()}");
                TreeItems.ToList().ForEach(_ => Console.WriteLine(_.LeafId));
            Console.WriteLine($"Invoking Change {TreeItems.Select(_ => _.LeafId)}");
            SelectedItem = TreeItems.GetLeafById(id);
            this.TestComponentViewModel = SelectedItem.ViewModel;
            Console.WriteLine($"selectedItem == null: {SelectedItem == null}");
            await StateChanged.Invoke(sender, SELECTED_ITEM).ConfigureAwait(false);
        }
    }
}





