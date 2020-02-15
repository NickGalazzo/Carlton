using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
{
    public class CarltonTreeViewModel
    {
        public IList<TreeItem> TreeItems { get; }

        private TreeItem _selectedItem;
        public TreeItem SelectedItem 
        { 
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                SelectedItemChanged?.Invoke(this, new EventArgs());
            }
        }
        public event EventHandler SelectedItemChanged;

        public CarltonTreeViewModel(IList<TreeItem> treeItems)
        {
            TreeItems = treeItems;
            SelectedItem = treeItems.FirstOrDefault().Children.FirstOrDefault();
            System.Console.WriteLine($"first {SelectedItem.DisplayName}");
        }

        public CarltonTreeViewModel()
        {
            TreeItems = new List<TreeItem>();
        }
    }
}
