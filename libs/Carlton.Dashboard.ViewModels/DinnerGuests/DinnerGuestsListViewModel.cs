using Newtonsoft.Json;
using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestsListViewModel
    {
        public DinnerGuestSelfStatusViewModel MyDinnerGuestStatus { get; private set; }
        public IEnumerable<DinnerGuestsListItemViewModel> DinnerGuests { get; private set; }


        public DinnerGuestsListViewModel(DinnerGuestSelfStatusViewModel myDinnerGuestStatus, IEnumerable<DinnerGuestsListItemViewModel> dinnerGuests)
        {
            MyDinnerGuestStatus = myDinnerGuestStatus;
            DinnerGuests = dinnerGuests;
        }

        [JsonConstructor]
        private DinnerGuestsListViewModel()
        {
            DinnerGuests = new List<DinnerGuestsListItemViewModel>();

        }
    }
}
