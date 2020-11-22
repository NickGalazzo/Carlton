using Carlton.Base.Client.State.Contracts;
using Carlton.Dashboard.ViewModels.DinnerGuests;

namespace Carlton.Dashboard.Components.DinnerGuests.Events
{
    public class DinnerGuestsReasonChangedEvent : ICarltonComponentEvent
    {
        public int DinnerGuestId { get; }
        public int ReasonId { get; }
        public object EventData { get; set; }

        public string EventName => throw new System.NotImplementedException();

        public DinnerGuestsReasonChangedEvent(int dinnerGuestId, int reasonId)
        {
            DinnerGuestId = dinnerGuestId;
            ReasonId = reasonId;
        }
    }
}
