using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.State;
using Carlton.TestBed.Components;
using Carlton.TestBed.Pages;
using Carlton.TestBed.Utils;
using Carlton.Base.Client.Components;
using Carlton.Base.Client.Components.TestData;
using Carlton.Base.Client.Components.Test;
using Carlton.Dashboard.ViewModels.TestViewModels;
using Carlton.Dashboard.Components;

namespace Carlton.TestBed.Client
{
    public static class Program
    {
        private const string BASE_COMPONENTS = "Base Components";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.AddCarltonTestBed(builder =>
            {
                //Base Components
                builder.AddComponent<Card>($"{BASE_COMPONENTS}/Cards/Card", CardTestStates.DefaultState());
                builder.AddComponent<ListCard<string>>($"{BASE_COMPONENTS}/Cards/ListCard", CardTestStates.DefaultListState());
                builder.AddComponent<Header>($"{BASE_COMPONENTS}/Header");
                builder.AddComponent<Logo>($"{BASE_COMPONENTS}/Logo");
                builder.AddComponent<HamburgerCollapser>($"{BASE_COMPONENTS}/HamburgerCollapser");
                builder.AddComponent<UserProfile>($"{BASE_COMPONENTS}/UserProfile");
                builder.AddComponent<Checkbox>($"{BASE_COMPONENTS}/checkbox/Checked", CheckboxTestStates.CheckedState());
                builder.AddComponent<Checkbox>($"{BASE_COMPONENTS}/checkbox/Unchecked", CheckboxTestStates.UncheckedState());
                builder.AddComponent<Select>($"{BASE_COMPONENTS}/Select/Default", SelectTestStates.Default());
                builder.AddComponent<ResizablePanel>($"{BASE_COMPONENTS}/ResizablePanel/Default");
                builder.AddComponent<Select>($"{BASE_COMPONENTS}/Select/Default", SelectTestStates.Default());
                //ToDos
                builder.AddCarltonComponent<ToDoListItem>("ToDos/ListItem/Checked", ToDoListTestViewModels.ToDoListItemCheckedViewModel());
                builder.AddCarltonComponent<ToDoListItem>("ToDos/ListItem/Unchecked", ToDoListTestViewModels.ToDoListItemUncheckedViewModel());
                builder.AddCarltonComponent<ToDoListCard>("ToDos/ListCard/Default", ToDoListTestViewModels.DefaultToDoListViewModel());
                //ApartmentStatus
                builder.AddCarltonComponent<ApartmentStatusListItem>("ApartmentStatus/ListItem/Completed", ApartmentStatusTestViewModels.CompletedStatusViewModel());
                builder.AddCarltonComponent<ApartmentStatusListItem>("ApartmentStatus/ListItem/Incomplete", ApartmentStatusTestViewModels.InCompleteStatusViewModel());
                builder.AddCarltonComponent<ApartmentStatusListCard>("ApartmentStatus/ListCard/Default", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel());
                //DinnerGuests
                builder.AddCarltonComponent<DinnerGuestsSelfStatus>("DinnerGuests/SelfStatus/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel());
                builder.AddCarltonComponent<DinnerGuestsSelfStatus>("DinnerGuests/SelfStatus/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel());
                builder.AddCarltonComponent<DinnerGuestsListItem>("DinnerGuests/ListItem/HomeForDinner", DinnerGuestsTestViewModels.DinnerGuestHomeViewModel());
                builder.AddCarltonComponent<DinnerGuestsListItem>("DinnerGuests/ListItem/NotHomeForDinner", DinnerGuestsTestViewModels.DinnerGuestNotHomeViewModel());
                builder.AddCarltonComponent<DinnerGuestsListCard>("DinnerGuests/ListCard", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel());
                //Groceries
                builder.AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/Low", GroceriesTestViewModels.GroceriesLowListItemViewModel());
                builder.AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/Medium", GroceriesTestViewModels.GroceriesMediumListItemViewModel());
                builder.AddCarltonComponent<GroceriesListItem>("Groceries/ListItems/High", GroceriesTestViewModels.GroceriesHighListItemViewModel());
                builder.AddCarltonComponent<GroceriesListCard>("Groceries/ListCard/Default", GroceriesTestViewModels.DefaultGroceriesListViewModel());
                //Feed
                builder.AddCarltonComponent<FeedListItem>("Feed/ListItem", FeedListTestViewModels.DefaultFeedListItemViewModel());
                builder.AddCarltonComponent<FeedListCard>("Feed/ListCard", FeedListTestViewModels.DefaultFeedItemListViewModel());
                //CountCards
                builder.AddCarltonComponent<ToDosCountCard>("CountCards/ToDos/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel());
                builder.AddCarltonComponent<ApartmentStatusCountCard>("CountCards/ApartmentStatus/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel());
                builder.AddCarltonComponent<DinnerGuestsCountCard>("CountCards/DinnerGuesets/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel());
                builder.AddCarltonComponent<GroceriesCountCard>("CountCards/Groceries/Default", DashboardAggregationsTestViewModels.DefaultDashboardAggregationViewModel());
            }, typeof(TestBed.Pages.TestBed).Assembly);


            builder.RootComponents.Add<App>("app");
            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
