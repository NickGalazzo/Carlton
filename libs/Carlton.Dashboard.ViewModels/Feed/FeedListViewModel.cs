using Carlton.Dashboard.ViewModels.Contracts;
using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;


namespace Carlton.Dashboard.Components.Feed
{
    public class FeedViewModel
    {
        public IList<IGroupedItems<FeedItem>> GroupedFeedItems { get; set; }

        public FeedViewModel()
        {
            GroupedFeedItems = new List<IGroupedItems<FeedItem>>();
        }
    }






}



