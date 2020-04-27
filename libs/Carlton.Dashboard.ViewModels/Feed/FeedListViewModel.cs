using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;

namespace Carlton.Dashboard.Components.Feed
{
    public class FeedListViewModel 
    {
        public IEnumerable<FeedListItemViewModel> FeedItems { get; }

        public FeedListViewModel(IEnumerable<FeedListItemViewModel> feedItems)
        {
            FeedItems = feedItems;
        }
    }
}



