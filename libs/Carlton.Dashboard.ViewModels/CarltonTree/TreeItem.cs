using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Dashboard.ViewModels.CarltonTree
{
    public class TreeItem
    {
        public string Text { get; set; }
        public IEnumerable<TreeItem> Children { get; set; }

        public TreeItem()
        {
            Children = new List<TreeItem>();
        }
    }
}
