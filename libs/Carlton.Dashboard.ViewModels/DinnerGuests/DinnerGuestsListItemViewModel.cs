namespace Carlton.Dashboard.ViewModels.DinnerGuests
{
    public class DinnerGuestsListItemViewModel
    {
        public string Name { get; private set; }
        public bool IsHomeForDinner { get; private set; }
        public string Reason { get; private set; }

        public DinnerGuestsListItemViewModel(string name, bool isHomeForDinner, string reason)
        {
            Name = name;
            IsHomeForDinner = isHomeForDinner;
            Reason = reason;
        }
    }
}

