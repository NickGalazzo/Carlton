using Newtonsoft.Json;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestsListItemViewModel
    {
        public int GuestId { get; private set; }
        public string GuestName { get; private set; }
        public bool IsHomeForDinner { get; private set; }
        public DinnerGuestReason Reason { get; private set; }

        [JsonConstructor]
        private DinnerGuestsListItemViewModel(int guestId, string guestName, bool isHomeForDinner, DinnerGuestReason reason)
        {
            GuestId = guestId;
            GuestName = guestName;
            IsHomeForDinner = isHomeForDinner;
            Reason = reason;
        }

        private DinnerGuestsListItemViewModel(int guestId, string guestName, bool isHomeForDinner)
            :this (guestId, guestName, isHomeForDinner, DinnerGuestReason.CreateDefaultNoneReason())
        {
        }

        public static DinnerGuestsListItemViewModel CreateHomeForDinnerGuest(int guestId, string guestName)
        {
            return new DinnerGuestsListItemViewModel(guestId, guestName, true);
        }

        public static DinnerGuestsListItemViewModel CreateNotHomeForDinnerGuest(int guestId, string guestName, DinnerGuestReason reason)
        {
            return new DinnerGuestsListItemViewModel(guestId, guestName, false, reason);
        }
    }
}

