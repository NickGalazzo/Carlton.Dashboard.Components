using Xunit;
using Bunit;
using Carlton.Dashboard.Models.TestModels;

namespace Carlton.Dashboard.Components.Test
{
    public class FeedTests : TestContext
    {
        [Fact]
        [Trait("FeedItem", "Snapshot")]
        public void FeedListItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.DefaultFeedListItemModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.FeedListItem);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Name_Verify()
        {
            // Arrange
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.DefaultFeedListItemModel())
            );

            // Act
            var feedName = cut.Find(".feed-title");

            // Assert
            Assert.Equal("Nick", feedName.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_Message_Verify()
        {
            // Arrange
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.DefaultFeedListItemModel())
            );

            // Act
            var feedMessage = cut.Find(".feed-message");

            // Assert
            Assert.Equal("Took Out Garbage", feedMessage.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_FeedDate_MomentsAgo_Verify()
        {
            // Arrange
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.DefaultFeedListItemModel())
            );

            // Act
            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("moments ago", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_FeedDate_MinutesAgo_Verify()
        {
            // Arrange
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.TenMinutesAgoFeedListItemModel())
            );

            // Act
            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("10 min(s) ago", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_FeedDate_HoursAgo_Verify()
        {
            // Arrange
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.ThreeHoursAgoFeedListItemModel())
            );

            // Act
            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("3 hr(s) ago", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItem", "Unit")]
        public void FeedListItem_FeedDate_PreviousDate_Verify()
        {
            // Assert
            var cut = RenderComponent<FeedListItem>(
                ("ViewModel", FeedListTestModels.PreviousDateFeedListItemModel())
            );

            // Act
            var feedDate = cut.Find(".feed-date");

            // Assert
            Assert.Equal("Oct 9", feedDate.TextContent);
        }

        [Fact]
        [Trait("FeedItemListCard", "Unit")]
        public void FeedListCard_FeedListItem_ChildCount_Verify()
        {
            // Arrange
            var cut = RenderComponent<FeedListCard>(
                ("ViewModel", FeedListTestModels.DefaultFeedItemListModel())
            );

            // Act
            var feedItems = cut.FindComponents<FeedListItem>();

            // Assert
            Assert.Equal(4, feedItems.Count);
        }

        [Fact]
        [Trait("FeedItemListCard", "Unit")]
        public void FeedListCard_FeedListItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<FeedListCard>(
                ("ViewModel", FeedListTestModels.DefaultFeedItemListModel())
            );

            // Act
            var feedItem = cut.FindComponent<FeedListItem>();

            // Assert
            feedItem.MarkupMatches(TestComponentMarkupConstants.FeedListItem);
        }
    }
}


 