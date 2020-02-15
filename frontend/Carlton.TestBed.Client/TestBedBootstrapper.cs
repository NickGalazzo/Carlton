using Carlton.Base.Infrastructure.Client.Components.Tree;
using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.Components.Feed;
using Carlton.Dashboard.Components.HomeForDinner;
using Carlton.Dashboard.Components.HouseholdItems;
using Carlton.Dashboard.Components.ToDos;
using Carlton.TestBed.Client.TestViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client
{
    public static class TestBedBootstrapper
    {
        public static CarltonTreeViewModel Bootstrap()
        {
            var builder = new TreeItemsBuilder()
              .AddTreeNode<ToDoListCard>("ToDoListCard", ToDoListViewModels.DefaultToDoList())
              .AddTreeNode<ApartmentStatusList>("Apartment Status", ApartmentStatusViewModels.DefaultApartmentStatusViewModel())
              .AddTreeNode<HomeForDinnerCard>("HomeForDinnerCard", HomeForDinnerViewModels.DefaultHomeForDinnerViewModel())
              .AddTreeNode<HouseholdItemsList>("HouseHoldItems", HouseholdItemsViewModels.DefaultHouseholdItemsViewModel())
              .AddTreeNode<FeedListCard>("FeedListCard", FeedListViewModels.DefaultFeedViewModels());
             //  .AddTreeNode<ToDoOverviewCard>("ToDoOverviewCard", new ToDoOverviewCardViewModel(7));
            
            return new CarltonTreeViewModel(builder.Build().ToList());
        }
    }
}
