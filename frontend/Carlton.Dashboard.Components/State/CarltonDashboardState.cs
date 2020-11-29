using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Carlton.Dashboard.ViewModels;

namespace Carlton.Dashboard.Components.State
{
    public class CarltonDashboardState //: ICarltonStateStore
    {
        public const string TO_DOS_STATE_CHANGE_EVENT = "ToDosStateChanged";
        public const string DINNER_GUESTS_STATE_CHANGE_EVENT = "DinnerGuestsStateChanged";
        public const string GROCERIES_STATE_CHANGE_EVENT = "GroceriesStateChanged";
        public const string FEED_STATE_CHANGE_EVENT = "FeedStateChanged";

        public event Func<object, string, Task> StateChanged;

        public IEnumerable<ToDo> ToDos { get; private set; }
        public IEnumerable<DinnerGuest> DinnerGuests { get; private set; }
        public IEnumerable<GroceryItem> Groceries { get; private set; }
        public IEnumerable<FeedItem> Feed { get; private set; }

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

        public void UpdateToDos(object sender, IEnumerable<ToDo> toDos)
        {
            ToDos = toDos;
            StateChanged?.Invoke(sender, TO_DOS_STATE_CHANGE_EVENT);
        }

        public void UpdateDinnerGuests(object sender, IEnumerable<DinnerGuest> dinnerGuests)
        {
            DinnerGuests = dinnerGuests;
            StateChanged?.Invoke(sender, DINNER_GUESTS_STATE_CHANGE_EVENT);
        }

        public void UpdateGroceries(object sender, IEnumerable<GroceryItem> groceries)
        {
            Groceries = groceries;
            StateChanged?.Invoke(sender, GROCERIES_STATE_CHANGE_EVENT);
        }

        public void UpdateFeed(object sender, IEnumerable<FeedItem> feed)
        {
            Feed = feed;
            StateChanged?.Invoke(sender, FEED_STATE_CHANGE_EVENT);
        }
    }
}
