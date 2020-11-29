using Bunit;
using Xunit;
using Carlton.Dashboard.ViewModels.TestViewModels;

namespace Carlton.Dashboard.Components.Test
{
    public class CountCardTests : TestContext
    {
        [Fact]
        [Trait("ApartmentStatusCountCard", "Snapshot")]
        public void ApartmentStatusCountCard_Markup()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusCount);
        }

        [Fact]
        [Trait("ApartmentStatusCountCard", "Unit")]
        public void ApartmentStatusCountCard_Count_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Act
            var count = cut.Find(".count-message").TextContent;

            // Assert
            Assert.Contains("7", count);
        }


        [Fact]
        [Trait("ToDosCountCard", "Snapshot")]
        public void ToDosCountCard_Markup()
        {
            // Arrange
            var cut = RenderComponent<ToDosCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ToDoCount);
        }

        [Fact]
        [Trait("ToDosCountCard", "Unit")]
        public void ToDosCountCard_Count_Verify()
        {
            // Assert
            var cut = RenderComponent<ToDosCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Act
            var count = cut.Find(".count-message").TextContent;

            // Assert
            Assert.Contains("7", count);
        }

        [Fact]
        [Trait("GroceriesCountCard", "Snapshot")]
        public void GroceriesCountCard_Markup()
        {
            //Arrange
            var cut = RenderComponent<GroceriesCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            //Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesCount);
        }

        [Fact]
        [Trait("GroceriesCountCard", "Unit")]
        public void GroceriesCountCard_Count_Verify()
        {
            // Arrange
            var cut = RenderComponent<GroceriesCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Act
            var count = cut.Find(".count-message").TextContent;

            // Assert
            Assert.Contains("7", count);
        }

        [Fact]
        [Trait("DinnerGuestsCountCard", "Snapshot")]
        public void DinnerGuestsCountCard_Markup()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsCount);
        }

        [Fact]
        [Trait("DinnerGuestsCountCard", "Unit")]
        public void DinnerGuestsCountCard_Count_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            // Act
            var count = cut.Find(".count-message").TextContent;

            // Assert
            Assert.Contains("7", count);
        }
    }
}
