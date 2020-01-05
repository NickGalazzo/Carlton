using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.Contracts
{
    public interface IGroupedItems<TItem>
    {
        string GroupName { get; set; }
        IList<TItem> Items { get; set; }
    }
}
