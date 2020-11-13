using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.ApartmentStatus
{
    public class ApartmentStatuses
    {
        public IEnumerable<ApartmentStatus> Statuses { get; private set; }

        public ApartmentStatuses(IEnumerable<ApartmentStatus> statuses)
        {
            Statuses = statuses;
        }
    }
}
