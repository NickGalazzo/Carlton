using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuests
    {
        public DinnerGuestSelfStatus MyDinnerGuestStatus { get; private set; }
        public IEnumerable<DinnerGuest> Items { get; private set; }


        public DinnerGuests(DinnerGuestSelfStatus myDinnerGuestStatus, IEnumerable<DinnerGuest> dinnerGuests)
        {
            MyDinnerGuestStatus = myDinnerGuestStatus;
            Items = dinnerGuests;
        }
    }
}
