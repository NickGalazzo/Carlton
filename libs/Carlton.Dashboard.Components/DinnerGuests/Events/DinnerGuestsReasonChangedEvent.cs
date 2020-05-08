namespace Carlton.Dashboard.Components.DinnerGuests.Events
{
    public class DinnerGuestsReasonChangedEvent
    {
        public int GuestId { get; }
        public int ReasonId { get; }

        public DinnerGuestsReasonChangedEvent(int guestId, int reasonId)
        {
            GuestId = guestId;
            ReasonId = reasonId;
        }
    }
}
