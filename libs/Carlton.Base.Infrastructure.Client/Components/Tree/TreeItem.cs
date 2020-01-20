using System.Collections.Generic;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
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
