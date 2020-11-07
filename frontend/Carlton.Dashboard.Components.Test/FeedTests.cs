using Bunit;
using Carlton.Dashboard.Components.Feed;
using Carlton.TestBed.Client.TestViewModels;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class FeedTests : TestContext
    {
        [Fact]
        [Trait("FeedItem", "Snapshot")]
        public void FeedListItem_Markup()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.DefaultFeedListItemViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.FeedListItem);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Verify_Name()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.DefaultFeedListItemViewModel())
            );

            var feedName = cut.Find(".feed-title");

            // Assert
            Assert.Equal("Nick", feedName.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Verify_Message()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.DefaultFeedListItemViewModel())
            );

            var feedMessage = cut.Find(".feed-message");

            // Assert
            Assert.Equal("Took Out Garbage", feedMessage.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Verify_FeedDate_MomentsAgo()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.DefaultFeedListItemViewModel())
            );

            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("moments ago", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Verify_FeedDate_MinutesAgo()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.TenMinutesAgoFeedListItemViewModel())
            );

            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("10 min(s) ago", feedDate.TextContent);
        }


        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Verify_FeedDate_HoursAgo()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.ThreeHoursAgoFeedListItemViewModel())
            );

            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("3 hr(s) ago", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Verify_FeedDate_PreviousDate()
        {
            // Act
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestViewModels.PreviousDateFeedListItemViewModel())
            );

            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("Oct 9", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItemListCard", "Unit")]
        public void FeedListCard_Verify_Four_Items()
        {
            // Act
            var cut = RenderComponent<FeedListCard>(
                ("ViewModel", FeedListTestViewModels.DefaultFeedListViewModel())
            );

            var feedItems = cut.FindComponents<FeedListItem>();

            // Assert
            Assert.Equal(4, feedItems.Count);
        }
    }
}


 