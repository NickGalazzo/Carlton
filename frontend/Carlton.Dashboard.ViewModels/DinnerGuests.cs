using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels
{
    public record DinnerGuests(DinnerGuestSelfStatus MyDinnerGuestStatus, IEnumerable<DinnerGuest> Guests);
    public record DinnerGuestSelfStatus(DinnerGuest MyGuestStatus, IEnumerable<DinnerGuestReason> MySavedReasons);
    public record DinnerGuestReason(int ReasonId, string ReasonText);
    public record DinnerGuestsHomeForDinnerStatusChangeEvent(int DinnerGuestId, bool IsHomeForDinner);
    public record DinnerGuestsReasonChangedEvent(int DinnerGuestId, int ReasonId);


    public record DinnerGuest
    {
        public int GuestId { get; init; }
        public string GuestName { get; init; }
        public bool IsHomeForDinner { get; init; }
        public DinnerGuestReason Reason { get; init; }

        private DinnerGuest(int guestId, string guestName, bool isHomeForDinner, DinnerGuestReason reason)
            => (GuestId, GuestName, IsHomeForDinner, Reason) = (guestId, guestName, isHomeForDinner, reason);

        public static DinnerGuest CreateHomeForDinnerGuest(int guestId, string guestName)
            => new DinnerGuest(guestId, guestName, true, new DinnerGuestReason(-1, string.Empty));

        public static DinnerGuest CreateNotHomeForDinnerGuest(int guestId, string guestName, DinnerGuestReason reason)
            => new DinnerGuest(guestId, guestName, false, reason);
    }
}
