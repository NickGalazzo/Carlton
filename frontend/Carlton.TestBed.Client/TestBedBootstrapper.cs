// Nicholas Galazzo
// Instructions: This project is intended to be used by any 
// application making use of the Carlton framework
// Simply include references to the projects for both the components
// being tested as well as the project containing the ViewModels for those components
// The testbed can then be used by simply modifying this bootstrappper file

using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.Components.HomeForDinner;
using Carlton.Dashboard.Components.HouseholdItems;
using Carlton.Dashboard.Components.ToDo;
using Carlton.Dashboard.Components.CountCards;
using Carlton.TestBed.Client.TestViewModels;
using Carlton.Dashboard.ViewModels.TestViewModels;
using Carlton.Base.Client.Components.Notifications;
using Carlton.Base.Client.Components.Checkbox;
using Carlton.TestBed.TestBedNavTree;
using Carlton.Base.Client.Components.Select;
using Carlton.Base.Client.Components.Test;

namespace Carlton.TestBed.Client
{
    public static class TestBedBootstrapper
    {
        public static TestBedService Bootstrap()
        {
            var builder = new TestBadNavTreeBuilder()
              .AddSimpleComponent<CarltonCheckbox>("Checked", CarltonCheckboxTestStates.CheckedState())
              .AddSimpleComponent<CarltonCheckbox>("Unchecked", CarltonCheckboxTestStates.UncheckedState())
              .AddSimpleComponent<CarltonSelect>("Default", CarltonSelectCheckboxTestStates.Default())
              .AddSimpleComponent<CarltonAlertNotification>("Default")
              .AddSimpleComponent<CarltonInfoNotification>("Default")
              .AddSimpleComponent<CarltonFailureNotification>("Default")
              .AddSimpleComponent<CarltonSuccessNotification>("Default")
              .AddCarltonComponent<ToDoListCard>("ToDoListCard", ToDoListTestViewModels.DefaultToDoList())
              .AddCarltonComponent<ToDoListItem>("Checked", ToDoListTestViewModels.DefaultToDoList().ToDoList[0])
              .AddCarltonComponent<ApartmentStatusList>("Apartment Status", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel())
              .AddCarltonComponent<HomeForDinnerCard>("HomeForDinnerCard", HomeForDinnerTestViewModels.DefaultHomeForDinnerViewModel())
              .AddCarltonComponent<HouseholdItemsList>("HouseHoldItems", HouseholdItemsTestViewModels.DefaultHouseholdItemsViewModel())
              .AddCarltonComponent<FeedListCard>("FeedListCard", FeedListTestViewModels.DefaultFeedViewModels())
              .AddCarltonComponent<ToDosCountCard>("Default", ToDosCountTestViewModels.DefaultToDoListViewModel())
              .AddCarltonComponent<ApartmentStatusCountCard>("Default", ApartmentStatusCountCardTestViewModels.DefaultApartmentStatusCountCardViewModel())
              .AddCarltonComponent<DinnerGuestsCountCard>("Default", DinnerGuestsCountCardTestViewModels.DefaultDinngerGuestsCountCardViewModel())
              .AddCarltonComponent<HouseholdItemsCountCard>("Default", HouseholdItemsCountCardTestViewModels.DefaultHouseholdItemsCountCardViewModel());

            return new TestBedService(builder.Build());
        }
    }
}
