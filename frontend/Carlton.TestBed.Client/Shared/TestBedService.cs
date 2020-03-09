using System.Linq;
using System.Collections.Generic;
using Carlton.Base.Infrastructure.Client.Events;
using Carlton.Base.Infrastructure.Client.Components.Tree;
using System;

namespace Carlton.Base.Infrastructure.Client.Components.TestBed
{
    public class TestBedService
    {
        private TreeItem _selectedItem;
        public IEnumerable<TreeItem> TreeItems { get; }
        public TreeItem SelectedItem
        {
            get { return _selectedItem; }

            private set
            {

                _selectedItem = value;
                TestComponentType = value.Type;
                TestComponentViewModel = value.ViewModel;
            }
        }

        public Type TestComponentType { get; private set; }
        public object TestComponentViewModel { get; private set; }

        public IList<IComponentEvent> ComponentEvents { get; private set; }

        public TestBedService(IEnumerable<TreeItem> treeItems)
        {
            TreeItems = treeItems;
            ComponentEvents = new List<IComponentEvent>();
            SelectedItem = treeItems.FirstOrDefault().Children.FirstOrDefault();
        }

        public void SelectItem(TreeItem item)
        {
            SelectedItem = item;
        }

        public void UpdateTestComponentViewModel(object viewModel)
        {
            TestComponentViewModel = viewModel;
        }

        public void AddComponentEvent(IComponentEvent evt)
        {
            ComponentEvents.Add(evt);
        }

        public void ClearEvents()
        {
            ComponentEvents.Clear();
        }
    }
}
