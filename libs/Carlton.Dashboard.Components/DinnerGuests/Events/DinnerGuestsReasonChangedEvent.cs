namespace Carlton.Dashboard.Components.DinnerGuests.Events
{
    public class DinnerGuestsReasonChangedEvent
    {
        public int DinnerGuestId { get; }
        public int ReasonId { get; }
        public object EventData { get; set; }

        public DinnerGuestsReasonChangedEvent(int dinnerGuestId, int reasonId)
        {
            DinnerGuestId = dinnerGuestId;
            ReasonId = reasonId;
        }
    }
}
