using System;
using System.Collections.Generic;
using System.Linq;


namespace Carlton.Dashboard.ViewModels.TestViewModels
{
    public static class FeedListTestViewModels
    {
        public static FeedItems DefaultFeedItemListViewModel()
        {
            const string TOOK_OUT_GARBAGE = "Took Out Garbage";
            var feedItems = new List<FeedItem>();
            var feedUser = new FeedUser("Nick", string.Empty);

         
            feedItems.Add(new FeedItem("Garbage", TOOK_OUT_GARBAGE, feedUser, DateTimeOffset.Now));

            feedItems.Add(new FeedItem("Garbage", TOOK_OUT_GARBAGE, feedUser, DateTimeOffset.Now.AddMinutes(-10)));

            feedItems.Add(new FeedItem("Groceries", "Purchahsed Groceries", feedUser, DateTimeOffset.Now.AddHours(-3)));

            feedItems.Add(new FeedItem("Groceries", "Purchahsed Groceries", feedUser, new DateTime(1989, 10, 9, 2, 7, 0, 0)));


            return new FeedItems(feedItems);
        }
    
        public static FeedItem DefaultFeedListItemViewModel()
        {
            return DefaultFeedItemListViewModel().Items.First();
        }

        public static FeedItem MomentsAgoFeedListItemViewModel()
        {
            return DefaultFeedItemListViewModel().Items.First();
        }
        public static FeedItem TenMinutesAgoFeedListItemViewModel()
        {
            return DefaultFeedItemListViewModel().Items.ElementAt(1);
        }

        public static FeedItem ThreeHoursAgoFeedListItemViewModel()
        {
            return DefaultFeedItemListViewModel().Items.ElementAt(2);
        }

        public static FeedItem PreviousDateFeedListItemViewModel()
        {
            return DefaultFeedItemListViewModel().Items.ElementAt(3);
        }
    }
}
