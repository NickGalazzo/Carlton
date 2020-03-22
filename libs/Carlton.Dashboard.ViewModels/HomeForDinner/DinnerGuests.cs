namespace Carlton.Dashboard.ViewModels.HomeForDinner
{
    public class DinnerGuest
    {
        public string Name { get; set; }
        public bool IsHomeForDinner { get; set; }
        public string Reason { get; set; }

        public DinnerGuest(string name, bool isHomeForDinner, string reason)
        {
            Name = name;
            IsHomeForDinner = isHomeForDinner;
            Reason = reason;
        }
    }
}

