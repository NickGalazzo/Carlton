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
                DinnerGuests = new List<DinnerGuests>()
                  {
                        new DinnerGuests("Nick", true, string.Empty),
                        new DinnerGuests("Steve", false, "Japaneese Class")
                  }
            };
        }
    }
}
