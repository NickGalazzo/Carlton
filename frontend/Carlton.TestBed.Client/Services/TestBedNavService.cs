using System;
using System.Collections.Generic;
using Carlton.TestBed.Client.Utils;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client.Services
{
    public class TestBedNavService
    {
        public event EventHandler<TestBedNavTreeItem> SelectedItemChanged;

        //All TestBed Nav Items
        public IEnumerable<TestBedNavTreeItem> NavTree { get; }

        //Selected Item Properties
        public TestBedNavTreeItem SelectedItem { get; private set; }
        public Type TestComponentType { get { return SelectedItem.Type; } }
        public bool IsTestComponentCarltonComponent { get { return SelectedItem.IsCarltonComponent; } }
      
        public TestBedNavService(IEnumerable<TestBedNavTreeItem> navTree)
        {
            NavTree = navTree;
            SelectedItem = navTree.GetFirstSelectableTestState();
        }

        public void SelectItem(TestBedNavTreeItem item)
        {
            SelectedItem = item;
            SelectedItemChanged?.Invoke(this, item);
        }
    }
}
