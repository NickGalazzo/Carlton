using Carlton.TestBed.TestBedNavTree;
using System;
using System.Collections.Generic;
using Carlton.TestBed.Client.Utils;

namespace Carlton.TestBed.Client.Services
{
    public class TestBedNavService
    {
        public event EventHandler<TestBedNavTreeItem> SelectedItemChanged;

        //All TestBed Nav Items
        public IEnumerable<TestBedNavTreeItem> TreeItems { get; }

        //Selected Item Properties
        public TestBedNavTreeItem SelectedItem { get; private set; }
        public Type TestComponentType { get { return SelectedItem.Type; } }
        public bool IsTestComponentCarltonComponent { get { return SelectedItem.IsCarltonComponent; } }
      
        public TestBedNavService(IEnumerable<TestBedNavTreeItem> treeItems)
        {
            TreeItems = treeItems;
            SelectedItem = treeItems.GetFirstSelectableTestState();
        }

        public void SelectItem(TestBedNavTreeItem item)
        {
            SelectedItem = item;
            SelectedItemChanged?.Invoke(this, item);
        }
    }
}
