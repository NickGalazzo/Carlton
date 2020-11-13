using Newtonsoft.Json;

namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuest
    {
        public int GuestId { get; private set; }
        public string GuestName { get; private set; }
        public bool IsHomeForDinner { get; private set; }
        public DinnerGuestReason Reason { get; private set; }

        [JsonConstructor]
        private DinnerGuest(int guestId, string guestName, bool isHomeForDinner, DinnerGuestReason reason)
        {
            GuestId = guestId;
            GuestName = guestName;
            IsHomeForDinner = isHomeForDinner;
            Reason = reason;
        }

        private DinnerGuest(int guestId, string guestName, bool isHomeForDinner)
            :this (guestId, guestName, isHomeForDinner, DinnerGuestReason.CreateDefaultNoneReason())
        {
        }

        public static DinnerGuest CreateHomeForDinnerGuest(int guestId, string guestName)
        {
            return new DinnerGuest(guestId, guestName, true);
        }

        public static DinnerGuest CreateNotHomeForDinnerGuest(int guestId, string guestName, DinnerGuestReason reason)
        {
            return new DinnerGuest(guestId, guestName, false, reason);
        }
    }
}

