using Newtonsoft.Json;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestsListItemViewModel
    {
        public string GuestName { get; private set; }
        public bool IsHomeForDinner { get; private set; }
        public DinnerGuestReason Reason { get; private set; }

        [JsonConstructor]
        private DinnerGuestsListItemViewModel(string guestName, bool isHomeForDinner, DinnerGuestReason reason)
        {
            GuestName = guestName;
            IsHomeForDinner = isHomeForDinner;
            Reason = reason;
        }

        private DinnerGuestsListItemViewModel(string guestName, bool isHomeForDinner)
            :this (guestName, isHomeForDinner, DinnerGuestReason.CreateDefaultNoneReason())
        {
        }

        public static DinnerGuestsListItemViewModel CreateHomeForDinnerGuest(string guestName)
        {
            return new DinnerGuestsListItemViewModel(guestName, true);
        }

        public static DinnerGuestsListItemViewModel CreateNotHomeForDinnerGuest(string guestName, DinnerGuestReason reason)
        {
            return new DinnerGuestsListItemViewModel(guestName, false, reason);
        }
    }
}

