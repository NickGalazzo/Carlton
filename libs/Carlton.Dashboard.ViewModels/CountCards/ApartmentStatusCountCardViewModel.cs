namespace Carlton.Dashboard.ViewModels.CountCards
{
    public class ApartmentStatusCountCardViewModel : CarltonBaseCountCardViewModel
    {
        private const string MESSAGE_TEMPLATE = "Pending Statuses";
        private const string ICON = "mdi-home";
        private const string ACCENT_COLOR = "accent-color-2";

        public ApartmentStatusCountCardViewModel(int count) :base(count, MESSAGE_TEMPLATE, ICON, ACCENT_COLOR)
        {
        }
    }
}
