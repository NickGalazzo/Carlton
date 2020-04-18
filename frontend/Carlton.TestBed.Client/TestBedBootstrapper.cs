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
using Carlton.TestBed.Client.Services;
using Carlton.Base.Client.Components.Cards;
using System.Collections.Generic;

namespace Carlton.TestBed.Client
{
    public static class TestBedBootstrapper
    {
        public static TestBedNavService Bootstrap()
        {
            var builder = new TestBadNavTreeBuilder()
              .AddComponent<CarltonCheckbox>("checkbox/Checked", CarltonCheckboxTestStates.CheckedState())
              .AddComponent<CarltonCheckbox>("checkbox/Unchecked", CarltonCheckboxTestStates.UncheckedState())
              .AddComponent<CarltonSelect>("Select/Default", CarltonSelectCheckboxTestStates.Default())

              .AddComponent<CarltonAlertNotification>("Notifications/Alert/Default")
              .AddComponent<CarltonInfoNotification>("Notifications/Info/Default")
              .AddComponent<CarltonFailureNotification>("Notifications/Failure/Default")
              .AddComponent<CarltonSuccessNotification>("Notifications/Success/Default")

              .AddCarltonComponent<ToDoListCard>("ToDos/ToDoListCard", ToDoListTestViewModels.DefaultToDoList())
              .AddCarltonComponent<ToDoListItem>("ToDos/ToDoListItem/Checked", ToDoListTestViewModels.DefaultToDoList().ToDoList[0])

              .AddCarltonComponent<ApartmentStatusList>("ApartmentStatus/Apartment Status", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel())
              .AddCarltonComponent<HomeForDinnerCard>("HomeForDinner/HomeForDinnerCard", HomeForDinnerTestViewModels.DefaultHomeForDinnerViewModel())
              .AddCarltonComponent<HouseholdItemsList>("HouseHoldItems/HouseHoldItems", HouseholdItemsTestViewModels.DefaultHouseholdItemsViewModel())
              .AddCarltonComponent<FeedListCard>("Feed/FeedListCard", FeedListTestViewModels.DefaultFeedViewModels())
              .AddCarltonComponent<ToDosCountCard>("CountCards/ToDos/Default", ToDosCountTestViewModels.DefaultToDoListViewModel())
              .AddCarltonComponent<ApartmentStatusCountCard>("CountCards/ApartmentStatus/Default", ApartmentStatusCountCardTestViewModels.DefaultApartmentStatusCountCardViewModel())
              .AddCarltonComponent<DinnerGuestsCountCard>("CountCards/DinnerGuesets/Default", DinnerGuestsCountCardTestViewModels.DefaultDinngerGuestsCountCardViewModel())
              .AddCarltonComponent<HouseholdItemsCountCard>("CountCards/HouseholdItems/Default", HouseholdItemsCountCardTestViewModels.DefaultHouseholdItemsCountCardViewModel());

            return new TestBedNavService(builder.Build());
        }
    }
}
