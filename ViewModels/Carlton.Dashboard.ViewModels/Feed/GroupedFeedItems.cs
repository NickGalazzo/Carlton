using Carlton.Dashboard.ViewModels.Contracts;
using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.Feed
{
    public class GroupedFeedItems : IGroupedItems<FeedItem>
    {
        public string GroupName { get; set; }
        public IList<FeedItem> Items { get; set; }
    }
}
