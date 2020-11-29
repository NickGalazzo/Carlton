using Xunit;
using Bunit;
using Carlton.Dashboard.ViewModels.TestViewModels;

namespace Carlton.Dashboard.Components.Test
{
    public class GroceriesTest : TestContext
    {
        [Fact]
        [Trait("GroceriesListItem", "Snapshot")]
        public void GroceriesListItem_Low_Markup()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesLowListItemViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_Low);
        }

        [Fact]
        [Trait("GroceriesListItem", "Snapshot")]
        public void GroceriesListItem_Medium_Markup()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesMediumListItemViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_Medium);
        }

        [Fact]
        [Trait("GroceriesListItem", "Snapshot")]
        public void GroceriesListItem_High_Markup()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesHighListItemViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_High);
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Label_Verify()
        {
            // Assert
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesLowListItemViewModel())
            );

            // Act
            var label = cut.Find(".item-name");

            // Assert
            Assert.Equal("Toilet Paper", label.TextContent);
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Progress_Verify()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesHighListItemViewModel())
            );

            // Act
            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.Equal("92", progressBar.GetAttribute("aria-valuenow"));
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Given_Count_LessThan_35_Should_Contain_Class_Low()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesLowListItemViewModel())
            );

            // Act
            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.True(progressBar.ClassList.Contains("low"));
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Given_Count_GreaterThan_35_And_LessThan_75_Should_Contain_Class_Medium()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesMediumListItemViewModel())
            );

            // Act
            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.True(progressBar.ClassList.Contains("medium"));
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Given_Count_GreaterThan_75_Should_Contain_Class_High()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", GroceriesTestViewModels.GroceriesHighListItemViewModel())
            );

            // Act
            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.True(progressBar.ClassList.Contains("high"));
        }

        [Fact]
        [Trait("GroceriesListCard", "Unit")]
        public void GroceriesListCard_GroceriesListItem_ChildCount_Verify()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListCard>(
                ("ViewModel", GroceriesTestViewModels.DefaultGroceriesListViewModel()));

            // Act
            var items = cut.FindComponents<GroceriesListItem>();

            // Assert
            Assert.Equal(4, items.Count);
        }

        [Fact]
        [Trait("GroceriesListCard", "Snapshot")]
        public void GroceriesListCard_GroceryItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<GroceriesListCard>(
                ("ViewModel", GroceriesTestViewModels.DefaultGroceriesListViewModel()));

            // Act
            var item= cut.FindComponent<GroceriesListItem>();

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_Low);        
        }
    }
}
