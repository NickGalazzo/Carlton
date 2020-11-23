using Carlton.Base.Client.State;

namespace Carlton.Dashboard.Components.DinnerGuests.Events
{
    public class DinnerGuestsHomeForDinnerStatusChangeEvent : ICarltonComponentEvent
    {
        public int DinnerGuestId { get; }
        public bool IsHomeForDinner { get; }

        public string EventName => throw new System.NotImplementedException();

        public DinnerGuestsHomeForDinnerStatusChangeEvent(int dinnerGuestId, bool isHomeForDinner)
        {
            DinnerGuestId = dinnerGuestId;
            IsHomeForDinner = isHomeForDinner;
        }
    }
}
