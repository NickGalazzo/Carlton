namespace Carlton.Dashboard.Components.DinnerGuests
{
    public class DinnerGuestsHomeForDinnerStatusChangeEvent
    {
        public int DinnerGuestId { get; }
        public bool IsHomeForDinner { get; }

        public DinnerGuestsHomeForDinnerStatusChangeEvent(int dinnerGuestId, bool isHomeForDinner)
        {
            DinnerGuestId = dinnerGuestId;
            IsHomeForDinner = isHomeForDinner;
        }
    }
}
