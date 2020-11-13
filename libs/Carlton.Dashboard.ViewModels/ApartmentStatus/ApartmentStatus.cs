namespace Carlton.Dashboard.ViewModels.ApartmentStatus
{
    public class ApartmentStatus
    {
        public ApartmentStatusName StatusName { get; private set; }
        public ApartmentStatusValue StatusValue { get; private set; }

        public ApartmentStatus(ApartmentStatusName statusName, ApartmentStatusValue statusValue)
        {
            StatusName = statusName;
            StatusValue = statusValue;
        }
    }
}
