using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuests
    {
        public DinnerGuestSelfStatusViewModel MyDinnerGuestStatus { get; private set; }
        public IEnumerable<DinnerGuest> Items { get; private set; }


        public DinnerGuests(DinnerGuestSelfStatusViewModel myDinnerGuestStatus, IEnumerable<DinnerGuest> dinnerGuests)
        {
            MyDinnerGuestStatus = myDinnerGuestStatus;
            Items = dinnerGuests;
        }
    }
}
