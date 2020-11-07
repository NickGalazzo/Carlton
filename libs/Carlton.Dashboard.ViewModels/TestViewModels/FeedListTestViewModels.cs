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

            feedItems.Add(new FeedListItemViewModel("Garbage", TOOK_OUT_GARBAGE, feedUser, DateTimeOffset.Now.AddMinutes(-10)));

            feedItems.Add(new FeedListItemViewModel("Groceries", "Purchahsed Groceries", feedUser, DateTimeOffset.Now.AddHours(-3)));

            feedItems.Add(new FeedListItemViewModel("Groceries", "Purchahsed Groceries", feedUser, new DateTime(1989, 10, 9, 2, 7, 0, 0)));


            return new FeedListViewModel(feedItems);
        }
    
        public static FeedListItemViewModel DefaultFeedListItemViewModel()
        {
            return DefaultFeedListViewModel().FeedItems.First();
        }

        public static FeedListItemViewModel MomentsAgoFeedListItemViewModel()
        {
            return DefaultFeedListViewModel().FeedItems.First();
        }
        public static FeedListItemViewModel TenMinutesAgoFeedListItemViewModel()
        {
            return DefaultFeedListViewModel().FeedItems.ElementAt(1);
        }

        public static FeedListItemViewModel ThreeHoursAgoFeedListItemViewModel()
        {
            return DefaultFeedListViewModel().FeedItems.ElementAt(2);
        }

        public static FeedListItemViewModel PreviousDateFeedListItemViewModel()
        {
            return DefaultFeedListViewModel().FeedItems.ElementAt(3);
        }
    }
}
