using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Dashboard.Components.Feed
{
    public class FeedViewModel 
    {
        public IList<GroupedFeedItems> GroupedFeedItems { get; set; }

        public FeedViewModel()
        {
            GroupedFeedItems = new List<GroupedFeedItems>();
        }
    }
}



