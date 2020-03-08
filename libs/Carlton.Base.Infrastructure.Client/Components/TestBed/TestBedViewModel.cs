using System.Linq;
using System.Collections.Generic;
using Carlton.Base.Infrastructure.Client.Events;
using Carlton.Base.Infrastructure.Client.Components.Tree;
using System;

namespace Carlton.Base.Infrastructure.Client.Components.TestBed
{
    public class TestBedViewModel
    {
        private TreeItem _selectedItem;
        public IList<TreeItem> TreeItems { get; }
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

        public TestBedViewModel(IList<TreeItem> treeItems)
        {
            TreeItems = treeItems;
            ComponentEvents = new List<IComponentEvent>();
            SelectedItem = treeItems.FirstOrDefault().Children.FirstOrDefault();
        }

        public void SelectItem(TreeItem item)
        {
            System.Console.WriteLine("component selected");
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
    }
}
