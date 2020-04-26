using Carlton.Dashboard.ViewModels.DinnerGuests;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class DinnerGuestsTestViewModels
    {
        public static DinnerGuestsListViewModel DefaultHomeForDinnerViewModel()
        {
            var dinnerGuests = new List<DinnerGuestsListItemViewModel>()
                {
                    new DinnerGuestsListItemViewModel("Nick", true, string.Empty),
                    new DinnerGuestsListItemViewModel("Steve", false, "Japaneese Class")
                };

            var mySavedReasons = new Dictionary<string, int>
                    {
                         {"Japan School", 1}
                    };

            var myDinnerGuestStatus = new DinnerGuestsListItemViewModel("Nick", true, string.Empty);

            var dinnerGuestSelfViewModel = new DinnerGuestSelfStatusViewModel(myDinnerGuestStatus, mySavedReasons);


            return new DinnerGuestsListViewModel(dinnerGuestSelfViewModel, dinnerGuests);
        }
    }
}
