namespace Carlton.Dashboard.ViewModels.CountCards
{
    public class CarltonBaseCountCardViewModel
    {
        public int Count { get; private set; }
        public string MessageTemplate { get; private set; }
        public string Icon { get; private set; }
        public string AccentColor { get; private set; }
        public string Message
        {
            get
            {
                return $"{Count} {MessageTemplate}";
            }
        }

        public CarltonBaseCountCardViewModel(int count, string messageTemplate, string icon, string accentColor)
        {
            Count = count;
            MessageTemplate = messageTemplate;
            Icon = icon;
            AccentColor = accentColor;
        }
    }
}
