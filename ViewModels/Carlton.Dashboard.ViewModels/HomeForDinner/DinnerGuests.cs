namespace Carlton.Dashboard.ViewModels.HomeForDinner
{
    public class DinnerGuests
    {
        public string Name { get; set; }
        public bool IsHomeForDinner { get; set; }
        public string Reason { get; set; }

        public DinnerGuests(string name, bool isHomeForDinner, string reason)
        {
            Name = name;
            IsHomeForDinner = isHomeForDinner;
            Reason = reason;
        }
    }
}

