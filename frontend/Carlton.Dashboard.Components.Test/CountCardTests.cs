using Bunit;
using Carlton.Dashboard.Components.CountCards;
using Carlton.Dashboard.ViewModels.TestViewModels;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class CountCardTests : TestContext
    {
        [Fact]
        [Trait("ApartmentStatusCountCard", "Snapshot")]
        public void ApartmentStatusCountCard_Markup()
        {
            //Act
            var cut = RenderComponent<ApartmentStatusCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            //Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusCount);
        }

        [Fact]
        [Trait("ApartmentStatusCountCard", "Unit")]
        public void ApartmentStatusCountCard_Count_Verify()
        {
            //Act
            var cut = RenderComponent<ApartmentStatusCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            var count = cut.Find(".count-message").TextContent;

            //Assert
            Assert.Contains("7", count);
        }


        [Fact]
        [Trait("ToDosCountCard", "Snapshot")]
        public void ToDosCountCard_Markup()
        {
            //Act
            var cut = RenderComponent<ToDosCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            //Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ToDoCount);
        }

        [Fact]
        [Trait("ToDosCountCard", "Unit")]
        public void ToDosCountCard_Count_Verify()
        {
            //Act
            var cut = RenderComponent<ToDosCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            var count = cut.Find(".count-message").TextContent;

            //Assert
            Assert.Contains("7", count);
        }

        [Fact]
        [Trait("GroceriesCountCard", "Snapshot")]
        public void GroceriesCountCard_Markup()
        {
            //Act
            var cut = RenderComponent<GroceriesCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            //Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesCount);
        }

        [Fact]
        [Trait("GroceriesCountCard", "Unit")]
        public void GroceriesCountCard_Count_Verify()
        {
            //Act
            var cut = RenderComponent<GroceriesCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            var count = cut.Find(".count-message").TextContent;

            //Assert
            Assert.Contains("7", count);
        }

        [Fact]
        [Trait("DinnerGuestsCountCard", "Snapshot")]
        public void DinnerGuestsCountCard_Markup()
        {
            //Act
            var cut = RenderComponent<DinnerGuestsCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            //Assert
            cut.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsCount);
        }

        [Fact]
        [Trait("DinnerGuestsCountCard", "Unit")]
        public void DinnerGuestsCountCard_Count_Verify()
        {
            //Act
            var cut = RenderComponent<DinnerGuestsCountCard>(
             ("ViewModel", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel()));

            var count = cut.Find(".count-message").TextContent;

            //Assert
            Assert.Contains("7", count);
        }
    }
}
