using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.ApartmentStatus
{
    public class ApartmentStatusListViewModel
    {
        public IEnumerable<ApartmentStatusListItemViewModel> Statuses { get; private set; }

        public ApartmentStatusListViewModel(IEnumerable<ApartmentStatusListItemViewModel> statuses)
        {
            Statuses = statuses;
        }
    }
}
