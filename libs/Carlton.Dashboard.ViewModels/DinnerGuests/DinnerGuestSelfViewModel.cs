using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestSelfStatusViewModel
    {
        public DinnerGuestsListItemViewModel MyGuestStatus { get; private set; }
        public IReadOnlyDictionary<string, int> MySavedReasons { get; private set; }

        public DinnerGuestSelfStatusViewModel(DinnerGuestsListItemViewModel myGuestStatus, IReadOnlyDictionary<string, int> mySavedResons)
        {
            MyGuestStatus = myGuestStatus;
            MySavedReasons = mySavedResons;
        }
    }
}
