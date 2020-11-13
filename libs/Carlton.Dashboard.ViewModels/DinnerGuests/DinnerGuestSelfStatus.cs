using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestSelfStatusViewModel
    {
        public DinnerGuest MyGuestStatus { get; private set; }
        public IEnumerable<DinnerGuestReason> MySavedReasons { get; private set; }

      
        public DinnerGuestSelfStatusViewModel(DinnerGuest myGuestStatus, IEnumerable<DinnerGuestReason> mySavedReasons)
        {
            MyGuestStatus = myGuestStatus;
            MySavedReasons = mySavedReasons;
        }
    }
}
