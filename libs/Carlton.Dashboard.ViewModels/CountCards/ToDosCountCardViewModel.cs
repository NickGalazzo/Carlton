namespace Carlton.Dashboard.ViewModels.CountCards
{
    public class ToDosCountCardViewModel : CarltonBaseCountCardViewModel
    {
        private const string MESSAGE_TEMPLATE = "Open Tasks";
        private const string ICON = "mdi-clipboard-check";
        private const string ACCENT_COLOR = "accent-color-one";

        public ToDosCountCardViewModel(int count) :base(count, MESSAGE_TEMPLATE, ICON, ACCENT_COLOR)
        {
        }
    }
}
