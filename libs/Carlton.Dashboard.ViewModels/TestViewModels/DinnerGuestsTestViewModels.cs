using Carlton.Dashboard.ViewModels.DinnerGuests;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class DinnerGuestsTestViewModels
    {
        public static IList<DinnerGuestReason> SampleReasons = new List<DinnerGuestReason>
                {
                    new DinnerGuestReason(1, "Japan School"),
                    new DinnerGuestReason(2, "Out With Friends")
                };


        public static DinnerGuestsListViewModel DefaultHomeForDinnerViewModel()
        {
            var dinnerGuests = new List<DinnerGuestsListItemViewModel>()
                {
                    DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                    DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(2, "Steve", SampleReasons[0])
                };

       
            var myDinnerGuestStatus = DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick");

            var dinnerGuestSelfViewModel = new DinnerGuestSelfStatusViewModel(myDinnerGuestStatus, SampleReasons);


            return new DinnerGuestsListViewModel(dinnerGuestSelfViewModel, dinnerGuests);
        }

        public static DinnerGuestsListItemViewModel DinnerGuestHomeViewModel()
        {
            return DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick");
        }

        public static DinnerGuestsListItemViewModel DinnerGuestNotHomeViewModel()
        {
            var reason = new DinnerGuestReason(1, "Japan School");
            return DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(2, "Steve", reason);
        }

        public static DinnerGuestSelfStatusViewModel DinnerGuestsSelfHomeViewModel()
        {
            return new DinnerGuestSelfStatusViewModel(DinnerGuestHomeViewModel(),
                new List<DinnerGuestReason>
                {
                    new DinnerGuestReason(1, "Japan School"),
                    new DinnerGuestReason(2, "Out With Friends")
                });
        }

        public static DinnerGuestSelfStatusViewModel DinnerGuestsSelfNotHomeViewModel()
        {
            return new DinnerGuestSelfStatusViewModel(DinnerGuestNotHomeViewModel(), SampleReasons);
        }
    }
}
