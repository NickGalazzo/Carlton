using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class FeedListTestViewModels
    {
        public static FeedListViewModel DefaultFeedListViewModel()
        {
            const string TOOK_OUT_GARBAGE = "Took Out Garbage";
            var feedItems = new List<FeedListItemViewModel>();
            var feedUser = new FeedUser("Nick", string.Empty);

         
            feedItems.Add(new FeedListItemViewModel("Garbage", TOOK_OUT_GARBAGE, feedUser, DateTimeOffset.Now));

            feedItems.Add(new FeedListItemViewModel("Garbage", TOOK_OUT_GARBAGE, feedUser, DateTimeOffset.Now));

            feedItems.Add(new FeedListItemViewModel("Groceries", "Purchahsed Groceries", feedUser, DateTime.Now));



            return new FeedListViewModel(feedItems);
        }
    
        public static FeedListItemViewModel DefaultFeedListItemViewModel()
        {
            return DefaultFeedListViewModel().FeedItems.First();
        }
    }
}
