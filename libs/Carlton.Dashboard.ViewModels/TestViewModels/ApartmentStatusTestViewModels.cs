using Carlton.Dashboard.ViewModels.ApartmentStatus;
using System.Collections.Generic;


namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ApartmentStatusTestViewModels
    {
        public static ApartmentStatusListViewModel DefaultApartmentStatusViewModel()
        {
            return new ApartmentStatusListViewModel()
            {
                Statuses = new List<ApartmentStatusListItemViewModel>
                     {
                            new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentRecycleStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentShoppingStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentCleaningStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentLaundryStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentDryCleaningStatusListItemViewModel(ApartmentStatuses.Incomplete)
                      }
            };
        }

        public static ApartmentStatusListItemViewModel CompletedStatusViewModel()
        {
            return new ApartmentStatusListItemViewModel("Garbage", ApartmentStatuses.Complete, "mdi-delete");
        }

        public static ApartmentStatusListItemViewModel InCompleteStatusViewModel()
        {
            return new ApartmentStatusListItemViewModel("Garbage", ApartmentStatuses.Incomplete, "mdi-delete");
        }
    }
}
