namespace Carlton.Dashboard.ViewModels.CountCards
{
    public class HouseholdItemsCountCardViewModel : CarltonBaseCountCardViewModel
    {
        private const string MESSAGE_TEMPLATE = "Low Items";
        private const string ICON = "mdi-cart";
        private const string ACCENT_COLOR = "accent-color-three";

        public HouseholdItemsCountCardViewModel(int count) : base(count, MESSAGE_TEMPLATE, ICON, ACCENT_COLOR)
        { }
    }
}
