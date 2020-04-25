using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.ApartmentStatus
{
    public class ApartmentStatusListViewModel
    {
        public List<ApartmentStatusListItemViewModel> Statuses { get; internal set; }

        public ApartmentStatusListViewModel(List<ApartmentStatusListItemViewModel> statuses)
        {
            Statuses = statuses;
        }

        public ApartmentStatusListViewModel()
        {
            Statuses = new List<ApartmentStatusListItemViewModel>();
        }
    }
}
