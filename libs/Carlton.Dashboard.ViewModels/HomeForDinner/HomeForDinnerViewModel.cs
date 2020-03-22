using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.HomeForDinner
{
    public class HomeForDinnerViewModel
    {
        public DinnerGuest MyGuestStatus { get; set; }
        public IReadOnlyDictionary<string, int> MySavedReasons { get; set; }
        public List<DinnerGuest> DinnerGuests { get; set; }
    }
}
