namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestReason
    {
        public int ReasonId { get; private set; }
        public string ReasonText { get; private set; }

        public DinnerGuestReason(int reasonId, string reasonText)
        {
            ReasonId = reasonId;
            ReasonText = reasonText;
        }

        public static DinnerGuestReason CreateDefaultNoneReason()
        {
            return new DinnerGuestReason(-1, string.Empty);
        }
    }
}
