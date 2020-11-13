using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestSelfStatus
    {
        public DinnerGuest MyGuestStatus { get; private set; }
        public IEnumerable<DinnerGuestReason> MySavedReasons { get; private set; }

      
        public DinnerGuestSelfStatus(DinnerGuest myGuestStatus, IEnumerable<DinnerGuestReason> mySavedReasons)
        {
            MyGuestStatus = myGuestStatus;
            MySavedReasons = mySavedReasons;
        }
    }
}
