using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Carlton.Dashboard.ViewModels
{
    public record DinnerGuests(DinnerGuestSelfStatus MyDinnerGuestStatus, IEnumerable<DinnerGuest> Guests);
    public record DinnerGuestSelfStatus(DinnerGuest MyGuestStatus, IEnumerable<DinnerGuestReason> MySavedReasons);
    public record DinnerGuestsHomeForDinnerStatusChangeEvent(int DinnerGuestId, bool IsHomeForDinner);
    public record DinnerGuestsReasonChangedEvent(int DinnerGuestId, int ReasonId);

    public record DinnerGuest
    {
        public int GuestId { get; init; }
        public string GuestName { get; init; }
        public bool IsHomeForDinner { get; init; }
        public DinnerGuestReason Reason { get; init; }

        [JsonConstructor]
        private DinnerGuest(int guestId, string guestName, bool isHomeForDinner, DinnerGuestReason reason)
            => (GuestId, GuestName, IsHomeForDinner, Reason) = (guestId, guestName, isHomeForDinner, reason);

        private DinnerGuest(int guestId, string guestName, bool isHomeForDinner)
            : this(guestId, guestName, isHomeForDinner, DinnerGuestReason.CreateNonReason())
        { }

        public static DinnerGuest CreateHomeForDinnerGuest(int guestId, string guestName)
            => new DinnerGuest(guestId, guestName, true);

        public static DinnerGuest CreateNotHomeForDinnerGuest(int guestId, string guestName, DinnerGuestReason reason)
            => new DinnerGuest(guestId, guestName, false, reason);
    }

    public record DinnerGuestReason
    {
        public int ReasonId { get; init; }
        public string ReasonText { get; init; }

        private DinnerGuestReason(int reasonId, string reasonText) => (ReasonId, ReasonText) = (reasonId, reasonText);

        public static DinnerGuestReason CreateReason(int reasonId, string reasonText) => new DinnerGuestReason(reasonId, reasonText);
        public static DinnerGuestReason CreateNonReason() => new DinnerGuestReason(-1, string.Empty);
    }
}
