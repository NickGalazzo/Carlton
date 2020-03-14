using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class FeedListViewModels
    {
        public static FeedViewModel DefaultFeedViewModels()
        {
            var feedViewModel = new FeedViewModel();

            const string TOOK_OUT_GARBAGE = "Took Out Garbage";
            feedViewModel.GroupedFeedItems.Add(
                        "Today",
                        new List<FeedItem>
                        {
                        new FeedItem("Garbage", TOOK_OUT_GARBAGE,
                            new FeedUser("Nick", string.Empty)),
                        new FeedItem("Household Items", "Purchahsed Household Items",
                            new FeedUser("Nick", string.Empty))
                    });

            feedViewModel.GroupedFeedItems.Add(
                "Yesterday",
                new List<FeedItem>
                {
                    new FeedItem("Garbage", TOOK_OUT_GARBAGE,
                        new FeedUser("Nick", string.Empty)),
                    new FeedItem("Household Items", "Purchahsed Household Items",
                        new FeedUser("Nick", string.Empty))
                }
            );

            return feedViewModel;
        }
    }
}
