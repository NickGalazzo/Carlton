using System.Collections.Generic;

namespace Carlton.Base.Infrastructure.Client.Components.Cards
{
    public class GroupedItems<TItem>
    {
        public string GroupName { get; set; }
        public IList<TItem> Items { get; set; }
    }
}
