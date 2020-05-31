// Nicholas Galazzo
// Instructions: This project is intended to be used by any 
// application making use of the Carlton framework
// Simply include references to the projects for both the components
// being tested as well as the project containing the ViewModels for those components
// The testbed can then be used by simply modifying this bootstrappper file

using Carlton.Dashboard.Components.Common;
using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.Components.DinnerGuests;
using Carlton.Dashboard.Components.Groceries;
using Carlton.Dashboard.Components.ToDos;
using Carlton.Dashboard.Components.CountCards;
using Carlton.Dashboard.Components.Header;
using Carlton.TestBed.Client.TestViewModels;
using Carlton.Dashboard.ViewModels.TestViewModels;
using Carlton.Base.Client.Components.Notifications;
using Carlton.Base.Client.Components.Checkbox;
using Carlton.TestBed.TestBedNavTree;
using Carlton.Base.Client.Components.Select;
using Carlton.Base.Client.Components.Test;
using Carlton.TestBed.Client.Services;
using System.Collections.Generic;
using Carlton.TestBed.Client.Shared;

namespace Carlton.TestBed.Client
{
    public static class TestBedBootstrapper
    {
        public static TestBedNavService Bootstrap()
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

              .AddCarltonComponent<ToDoListItem>("ToDos/ListItem/Checked", ToDoListTestViewModels.ToDoListItemChecked())
              .AddCarltonComponent<ToDoListItem>("ToDos/ListItem/Unchecked", ToDoListTestViewModels.ToDoListItemUnchecked())
              .AddCarltonComponent<ToDoListCard>("ToDos/ListCard/Default", ToDoListTestViewModels.DefaultToDoList())

              .AddCarltonComponent<ApartmentStatusListItem>("ApartmentStatus/ListItem/Completed", ApartmentStatusTestViewModels.CompletedStatusViewModel())
              .AddCarltonComponent<ApartmentStatusListItem>("ApartmentStatus/ListItem/Incomplete", ApartmentStatusTestViewModels.InCompleteStatusViewModel())
              .AddCarltonComponent<ApartmentStatusListCard>("ApartmentStatus/ListCard/Default", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel())

              .AddCarltonComponent<DinnerGuestsSelfStatus>("DinnerGuests/SelfStatus/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel())
              .AddCarltonComponent<DinnerGuestsSelfStatus>("DinnerGuests/SelfStatus/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel())
              .AddCarltonComponent<DinnerGuestListItemWithIndicator>("DinnerGuests/ListItem/WithIndicator/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestHomeViewModel())
              .AddCarltonComponent<DinnerGuestListItemWithIndicator>("DinnerGuests/ListItem/WithIndicator/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestNotHomeViewModel())
              .AddCarltonComponent<DinnerGuestListItemWithoutIndicator>("DinnerGuests/ListItem/WithoutIndicator/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestHomeViewModel())
              .AddCarltonComponent<DinnerGuestListItemWithoutIndicator>("DinnerGuests/ListItem/WithoutIndicator/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestNotHomeViewModel())
              .AddCarltonComponent<DinnerGuestsListCard>("DinnerGuests/ListCard", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel())

              .AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/Low", GroceriesTestViewModels.GroceriesLowListItemViewModel())
              .AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/Medium", GroceriesTestViewModels.GroceriesMediumListItemViewModel())
              .AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/High", GroceriesTestViewModels.GroceriesHighListItemViewModel())
              .AddCarltonComponent<GroceriesListCard>("Groceries/ListCard/Default", GroceriesTestViewModels.DefaultGroceriesListViewModel())

              .AddCarltonComponent<FeedListItem>("Feed/ListItem", FeedListTestViewModels.DefaultFeedListItemViewModel())
              .AddCarltonComponent<FeedListCard>("Feed/ListCard", FeedListTestViewModels.DefaultFeedListViewModel())

              .AddCarltonComponent<ToDosCountCard>("CountCards/ToDos/Default", ToDosCountTestViewModels.DefaultToDoListViewModel())
              .AddCarltonComponent<ApartmentStatusCountCard>("CountCards/ApartmentStatus/Default", ApartmentStatusCountCardTestViewModels.DefaultApartmentStatusCountCardViewModel())
              .AddCarltonComponent<DinnerGuestsCountCard>("CountCards/DinnerGuesets/Default", DinnerGuestsCountCardTestViewModels.DefaultDinngerGuestsCountCardViewModel())
              .AddCarltonComponent<GroceriesCountCard>("CountCards/Groceries/Default", GroceriesCountCardTestViewModels.DefaultGroceriesCountCardViewModel());

            var navTree = builder.Build();

            return new TestBedNavService(navTree);
        }
    }
}
