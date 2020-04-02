// Nicholas Galazzo
// Instructions: This project is intended to be used by any 
// application making use of the Carlton framework
// Simply include references to the projects for both the components
// being tested as well as the project containing the ViewModels for those components
// The testbed can then be used by simply modifying this bootstrappper file

using Carlton.Base.Infrastructure.Client.Components.Tree;
using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.Components.HomeForDinner;
using Carlton.Dashboard.Components.HouseholdItems;
using Carlton.Dashboard.Components.ToDo;
using Carlton.Dashboard.Components.CountCards;
using Carlton.TestBed.Client.TestViewModels;
using Carlton.Base.Infrastructure.Client.Components.TestBed;
using Carlton.Dashboard.ViewModels.TestViewModels;

namespace Carlton.TestBed.Client
{
    public static class TestBedBootstrapper
    {
        public static TestBedService Bootstrap()
        {
            var builder = new TreeItemsBuilder()
              .AddTreeNode<ToDoListCard>("ToDoListCard", ToDoListViewModels.DefaultToDoList())
              .AddTreeNode<ApartmentStatusList>("Apartment Status", ApartmentStatusViewModels.DefaultApartmentStatusViewModel())
              .AddTreeNode<HomeForDinnerCard>("HomeForDinnerCard", HomeForDinnerViewModels.DefaultHomeForDinnerViewModel())
              .AddTreeNode<HouseholdItemsList>("HouseHoldItems", HouseholdItemsViewModels.DefaultHouseholdItemsViewModel())
              .AddTreeNode<FeedListCard>("FeedListCard", FeedListViewModels.DefaultFeedViewModels())
              .AddTreeNode<ToDosCountCard>("Default", ToDosCountViewModels.DefaultToDoListViewModel())
              .AddTreeNode<ApartmentStatusCountCard>("Default", ApartmentStatusCountCardViewModels.DefaultApartmentStatusCountCardViewModel()) 
              .AddTreeNode<DinnerGuestsCountCard>("Default", DinnerGuestsCountCardViewModels.DefaultDinngerGuestsCountCardViewModel())
              .AddTreeNode<HouseholdItemsCountCard>("Default", HouseholdItemsCountCardViewModels.DefaultHouseholdItemsCountCardViewModel());
            
            return new TestBedService(builder.Build());
        }
    }
}
