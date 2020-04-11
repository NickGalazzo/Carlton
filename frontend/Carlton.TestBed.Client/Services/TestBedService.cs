using System;
using System.Collections.Generic;
using System.Linq;
using Carlton.TestBed.TestBedNavTree;
using Carlton.Base.Client.Enums;

namespace Carlton.TestBed
{
    public class TestBedService
    {
        private TestBadNavTreeItem _selectedItem;
        public IEnumerable<TestBadNavTreeItem> TreeItems { get; }
        public TestBadNavTreeItem SelectedItem
        {
            get { return _selectedItem; }

            private set
            {
                _selectedItem = value;
                TestComponentType = value.Type;
                TestComponentViewModel = value.ViewModel;
                TestComponentIsCarltonComponent = value.IsCarltonComponent;
            }
        }

        public Type TestComponentType { get; private set; }
        public object TestComponentViewModel { get; private set; }

        public bool TestComponentIsCarltonComponent { get; private set; }       

        public IList<object> ComponentEvents { get; private set; }

        public ComponentStatus ComponentStatus { get; private set; }

        public TestBedService(IEnumerable<TestBadNavTreeItem> treeItems)
        {
            TreeItems = treeItems;
            ComponentEvents = new List<object>();
            SelectedItem = GetFirstAvailableTestState(treeItems);
        }

        public void SelectItem(TestBadNavTreeItem item)
        {
            SelectedItem = item;
        }

        public void UpdateTestComponentViewModel(object viewModel)
        {
            TestComponentViewModel = viewModel;
        }

        public void AddComponentEvent(object evt)
        {
            ComponentEvents.Add(evt);
        }

        public void ClearEvents()
        {
            ComponentEvents.Clear();
        }

        public void UpdateComponentStatus(ComponentStatus status)
        {
            ComponentStatus = status;
        }

        private TestBadNavTreeItem GetFirstAvailableTestState(IEnumerable<TestBadNavTreeItem> treeItems)
        {
            var item = treeItems.First();

            while(item.Children.Any())
            {
                item = item.Children.First();
            } 

            return item;
        }
    }
}
