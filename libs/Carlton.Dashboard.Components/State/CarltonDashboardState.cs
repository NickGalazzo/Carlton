using Carlton.Dashboard.ViewModels.DinnerGuests;
using Carlton.Dashboard.ViewModels.Groceries;
using Carlton.Dashboard.ViewModels.ToDos;
using Carlton.Dashboard.ViewModels.Feed;
using System.Collections.Generic;

namespace Carlton.Dashboard.Components.State
{
    public class CarltonDashboardState
    {
        public IEnumerable<ToDo> ToDos { get; set; }
        public IEnumerable<DinnerGuest> DinnerGuests { get; set; }
        public IEnumerable<GroceryItem> Groceries { get; set; }
        public IEnumerable<FeedItem> Feed { get; set; }


        public CarltonDashboardState(CarltonDashboardState existingState, IEnumerable<ToDo> toDos)
            :this(toDos, existingState.DinnerGuests, existingState.Groceries, existingState.Feed)
        {
        }

        public CarltonDashboardState(CarltonDashboardState existingState, IEnumerable<DinnerGuest> guests)
          : this(existingState.ToDos, guests, existingState.Groceries, existingState.Feed)
        {
        }

        public CarltonDashboardState(CarltonDashboardState existingState, IEnumerable<FeedItem> feed)
    : this(existingState.ToDos, existingState.DinnerGuests, existingState.Groceries, feed)
        {
        }

        public CarltonDashboardState(IEnumerable<ToDo> toDos,
            IEnumerable<DinnerGuest> dinnerGuests,
            IEnumerable<GroceryItem> groceris,
            IEnumerable<FeedItem> feed)
        {
            ToDos = toDos;
            DinnerGuests = dinnerGuests;
            Groceries = groceris;
            Feed = feed;
        }
    }
}
