using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carlton.Dashboard.ViewModels.CarltonTree
{
    public class CarltonTreeViewModel
    {
        public IList<TreeItem> TreeItems { get; }
        public TreeItem SelectedItem { get; set; }

        public CarltonTreeViewModel(IList<TreeItem> treeItems)
        {
            TreeItems = treeItems;
            SelectedItem = treeItems.FirstOrDefault();
        }

        public CarltonTreeViewModel()
        {
            TreeItems = new List<TreeItem>();
        }
    }
}
