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

            feedViewModel.GroupedFeedItems.Add(
                    new GroupedFeedItems
                    {
                        GroupName = "Today",
                        Items = new List<FeedItem>
                        {
                        new FeedItem("Garbage", "Took Out Garbage",
                            new FeedUser("Nick", string.Empty)),
                        new FeedItem("Household Items", "Purchahsed Household Items",
                            new FeedUser("Nick", string.Empty))
                                }
                    });

            feedViewModel.GroupedFeedItems.Add(
            new GroupedFeedItems
            {
                GroupName = "Yesterday",
                Items = new List<FeedItem>
                {
                    new FeedItem("Garbage", "Took Out Garbage",
                        new FeedUser("Nick", string.Empty)),
                    new FeedItem("Household Items", "Purchahsed Household Items",
                        new FeedUser("Nick", string.Empty))
                        }
            });

            return feedViewModel;
        }
    }
}
