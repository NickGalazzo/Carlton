using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;

namespace Carlton.Dashboard.Components.Feed
{
    public class FeedViewModel 
    {
        public IDictionary<string, IEnumerable<FeedItem>> GroupedFeedItems { get; set; }

        public FeedViewModel()
        {
            GroupedFeedItems = new Dictionary<string, IEnumerable<FeedItem>>();
        }
    }
}



