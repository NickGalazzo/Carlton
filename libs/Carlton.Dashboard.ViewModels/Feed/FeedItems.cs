using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;

namespace Carlton.Dashboard.Components.Feed
{
    public class FeedItems 
    {
        public IEnumerable<FeedItem> Items { get; }

        public FeedItems(IEnumerable<FeedItem> feedItems)
        {
            Items = feedItems;
        }
    }
}



