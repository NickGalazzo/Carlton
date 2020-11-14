using Carlton.Dashboard.ViewModels.DinnerGuests;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class DinnerGuestsTestViewModels
    {
        private static readonly IList<DinnerGuestReason> SampleReasons = new List<DinnerGuestReason>
                {
                    new DinnerGuestReason(1, "Japan School"),
                    new DinnerGuestReason(2, "Out With Friends")
                };


        public static DinnerGuests DefaultHomeForDinnerViewModel()
        {
            var dinnerGuests = new List<DinnerGuest>()
                {
                    DinnerGuest.CreateHomeForDinnerGuest(1, "Nick"),
                    DinnerGuest.CreateNotHomeForDinnerGuest(2, "Steve", SampleReasons[0])
                };


            var myDinnerGuestStatus = DinnerGuest.CreateHomeForDinnerGuest(1, "Nick");
            var dinnerGuestSelfViewModel = new DinnerGuestSelfStatus(myDinnerGuestStatus, SampleReasons);

            return new DinnerGuests(dinnerGuestSelfViewModel, dinnerGuests);
        }

        public static DinnerGuest DinnerGuestHomeViewModel()
        {
            return DinnerGuest.CreateHomeForDinnerGuest(1, "Nick");
        }

        public static DinnerGuest DinnerGuestNotHomeViewModel()
        {
            var reason = new DinnerGuestReason(1, "Japan School");
            return DinnerGuest.CreateNotHomeForDinnerGuest(2, "Steve", reason);
        }

        public static DinnerGuestSelfStatus DinnerGuestsSelfHomeViewModel()
        {
            return new DinnerGuestSelfStatus(DinnerGuestHomeViewModel(),
                new List<DinnerGuestReason>
                {
                    new DinnerGuestReason(1, "Japan School"),
                    new DinnerGuestReason(2, "Out With Friends")
                });
        }

        public static DinnerGuestSelfStatus DinnerGuestsSelfNotHomeViewModel()
        {
            return new DinnerGuestSelfStatus(DinnerGuestNotHomeViewModel(), SampleReasons);
        }
    }
}
