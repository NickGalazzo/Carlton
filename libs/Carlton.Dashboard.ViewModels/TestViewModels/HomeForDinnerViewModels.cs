using Carlton.Dashboard.ViewModels.HomeForDinner;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class HomeForDinnerViewModels
    {
        public static HomeForDinnerViewModel DefaultHomeForDinnerViewModel()
        {
            return new HomeForDinnerViewModel()
            {
                MyGuestStatus = new DinnerGuest("Nick", true, string.Empty),
                DinnerGuests = new List<DinnerGuest>()
                {
                    new DinnerGuest("Nick", true, string.Empty),
                    new DinnerGuest("Steve", false, "Japaneese Class")
                },
                MySavedReasons = new Dictionary<string, int>
                {
                    {"Japan School", 1}
                }
            };
        }
    }
}
