namespace Carlton.Dashboard.ViewModels.CountCards
{
    public class DinnerGuestsCountCardViewModel : CarltonBaseCountCardViewModel
    {
        private const string MESSAGE_TEMPLATE = "Guests for Dinner";
        private const string ICON = "mdi-silverware-fork-knife";
        private const string ACCENT_COLOR = "accent-color-four";

        public DinnerGuestsCountCardViewModel(int count) : base(count, MESSAGE_TEMPLATE, ICON, ACCENT_COLOR)
        {
        }
    }
}
