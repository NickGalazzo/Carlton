using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels
{
    public enum ApartmentStatusValue
    {
        Complete = 1,
        Incomplete = 2
    }

    public enum ApartmentStatusName
    {
        Garbage,
        Recycle,
        Groceries,
        Cleaning,
        Laundry,
        DryCleaning
    }

    public record ApartmentStatus(ApartmentStatusName StatusName, ApartmentStatusValue StatusValue);

    public record ApartmentStatuses(IEnumerable<ApartmentStatus> Statuses);
}
