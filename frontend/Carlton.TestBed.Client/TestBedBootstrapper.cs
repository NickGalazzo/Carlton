// Nicholas Galazzo
// Instructions: This project is intended to be used by any 
// application making use of the Carlton framework
// Simply include references to the projects for both the components
// being tested as well as the project containing the ViewModels for those components
// The testbed can then be used by simply modifying this bootstrappper file

using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.Components.DinnerGuests;
using Carlton.Dashboard.Components.Groceries;
using Carlton.Dashboard.Components.ToDos;
using Carlton.Dashboard.Components.CountCards;
using Carlton.TestBed.Client.TestViewModels;
using Carlton.Dashboard.ViewModels.TestViewModels;
using Carlton.TestBed.TestBedNavTree;
using Carlton.TestBed.Client.Services;
using System.Collections.Generic;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client
{
    public static class TestBedBootstrapper
    {
        public static IEnumerable<TestBedNavTreeItem> Bootstrap()
        {
            var builder = new TestBadNavTreeBuilder()

              //.AddComponent<DashboardCardMenu>("SimpleMenu/Default", CarltonMenuTestStates.Default())
              //.AddComponent<TestBedSettingsMenu>("DropdownMenu/Default", CarltonMenuTestStates.SubMenu())

              //.AddComponent<Header>("header/default")

              //.AddComponent<CarltonCheckbox>("checkbox/Checked", CarltonCheckboxTestStates.CheckedState())
              //.AddComponent<CarltonCheckbox>("checkbox/Unchecked", CarltonCheckboxTestStates.UncheckedState())
              //.AddComponent<CarltonSelect>("Select/Default", CarltonSelectCheckboxTestStates.Default())

              //.AddComponent<CarltonAlertNotification>("Notifications/Alert/Default")
              //.AddComponent<CarltonInfoNotification>("Notifications/Info/Default")
              //.AddComponent<CarltonFailureNotification>("Notifications/Failure/Default")
              //.AddComponent<CarltonSuccessNotification>("Notifications/Success/Default")
              //.AddComponent<CarltonNotificationBar>("Notifications/NotificationBar/Default", new Dictionary<string, object> { { "NotificationType", CarltonNotificationBar.CarltonNotificationType.FAILURE } })

              .AddCarltonComponent<ToDoListItem>("ToDos/ListItem/Checked", ToDoListTestViewModels.ToDoListItemCheckedViewModel())
              .AddCarltonComponent<ToDoListItem>("ToDos/ListItem/Unchecked", ToDoListTestViewModels.ToDoListItemUncheckedViewModel())
              .AddCarltonComponent<ToDoListCard>("ToDos/ListCard/Default", ToDoListTestViewModels.DefaultToDoListViewModel())

              .AddCarltonComponent<ApartmentStatusListItem>("ApartmentStatus/ListItem/Completed", ApartmentStatusTestViewModels.CompletedStatusViewModel())
              .AddCarltonComponent<ApartmentStatusListItem>("ApartmentStatus/ListItem/Incomplete", ApartmentStatusTestViewModels.InCompleteStatusViewModel())
              .AddCarltonComponent<ApartmentStatusListCard>("ApartmentStatus/ListCard/Default", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel())

              .AddCarltonComponent<DinnerGuestsSelfStatus>("DinnerGuests/SelfStatus/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel())
              .AddCarltonComponent<DinnerGuestsSelfStatus>("DinnerGuests/SelfStatus/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel())
              .AddCarltonComponent<DinnerGuestsListItem>("DinnerGuests/ListItem/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestHomeViewModel())
              .AddCarltonComponent<DinnerGuestsListItem>("DinnerGuests/ListItem/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestNotHomeViewModel())
              .AddCarltonComponent<DinnerGuestsListCard>("DinnerGuests/ListCard", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel())

              .AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/Low", GroceriesTestViewModels.GroceriesLowListItemViewModel())
              .AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/Medium", GroceriesTestViewModels.GroceriesMediumListItemViewModel())
              .AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/High", GroceriesTestViewModels.GroceriesHighListItemViewModel())
              .AddCarltonComponent<GroceriesListCard>("Groceries/ListCard/Default", GroceriesTestViewModels.DefaultGroceriesListViewModel())

              .AddCarltonComponent<FeedListItem>("Feed/ListItem", FeedListTestViewModels.DefaultFeedListItemViewModel())
              .AddCarltonComponent<FeedListCard>("Feed/ListCard", FeedListTestViewModels.DefaultFeedItemListViewModel())

              .AddCarltonComponent<ToDosCountCard>("CountCards/ToDos/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel())
              .AddCarltonComponent<ApartmentStatusCountCard>("CountCards/ApartmentStatus/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel())
              .AddCarltonComponent<DinnerGuestsCountCard>("CountCards/DinnerGuesets/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel())
              .AddCarltonComponent<GroceriesCountCard>("CountCards/Groceries/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel());

            return builder.Build();
        }
    }
}
