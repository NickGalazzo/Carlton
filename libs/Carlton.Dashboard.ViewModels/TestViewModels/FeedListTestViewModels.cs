﻿using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class FeedListTestViewModels
    {
        public static FeedItems DefaultFeedItemList()
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
            return DefaultFeedItemList().Items.First();
        }

        public static FeedItem MomentsAgoFeedListItemViewModel()
        {
            return DefaultFeedItemList().Items.First();
        }
        public static FeedItem TenMinutesAgoFeedListItemViewModel()
        {
            return DefaultFeedItemList().Items.ElementAt(1);
        }

        public static FeedItem ThreeHoursAgoFeedListItemViewModel()
        {
            return DefaultFeedItemList().Items.ElementAt(2);
        }

        public static FeedItem PreviousDateFeedListItemViewModel()
        {
            return DefaultFeedItemList().Items.ElementAt(3);
        }
    }
}
