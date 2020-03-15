using Carlton.Base.Infrastructure.Client.Components.Tree;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IList<object> ComponentEvents { get; private set; }

        public TestBedService(IEnumerable<TreeItem> treeItems)
        {
            TreeItems = treeItems;
            ComponentEvents = new List<object>();
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

        public void AddComponentEvent(object evt)
        {
            ComponentEvents.Add(evt);
        }

        public void ClearEvents()
        {
            ComponentEvents.Clear();
        }
    }
}
