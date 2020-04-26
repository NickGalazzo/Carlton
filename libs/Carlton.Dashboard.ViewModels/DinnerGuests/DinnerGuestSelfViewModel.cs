using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestSelfStatusViewModel
    {
        public DinnerGuestsListItemViewModel MyGuestStatus { get; private set; }
        public IEnumerable<DinnerGuestReason> MySavedReasons { get; private set; }

      
        public DinnerGuestSelfStatusViewModel(DinnerGuestsListItemViewModel myGuestStatus, IEnumerable<DinnerGuestReason> mySavedReasons)
        {
            MyGuestStatus = myGuestStatus;
            MySavedReasons = mySavedReasons;
        }
    }
}
