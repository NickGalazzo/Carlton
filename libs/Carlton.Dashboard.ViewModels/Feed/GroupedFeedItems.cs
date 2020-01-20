using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.Feed
{
    public class GroupedFeedItems 
    {
        public string GroupName { get; set; }
        public IList<FeedItem> Items { get; set; }
    }
}
