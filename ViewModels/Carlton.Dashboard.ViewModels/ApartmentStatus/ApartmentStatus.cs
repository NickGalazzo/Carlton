namespace Carlton.Dashboard.ViewModels.ApartmentStatus
{
    public class ApartmentStatus
    {
        public string StatusName { get; set; }
        public ApartmentStatuses StatusValue { get; set; }
        public string StatusIcon { get; set; }

        public ApartmentStatus(string statusName, ApartmentStatuses statusValue, string statusIcon)
        {
            StatusName = statusName;
            StatusValue = statusValue;
            StatusIcon = statusIcon;
        }
    }
}
