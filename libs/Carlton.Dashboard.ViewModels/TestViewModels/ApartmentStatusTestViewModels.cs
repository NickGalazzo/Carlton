using Carlton.Dashboard.ViewModels.ApartmentStatus;
using System.Collections.Generic;


namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ApartmentStatusTestViewModels
    {
        public static ApartmentStatusListViewModel DefaultApartmentStatusViewModel()
        {
            var apartmentStatuses = new List<ApartmentStatusListItemViewModel>
                     {
                            new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentRecycleStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentShoppingStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentCleaningStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentLaundryStatusListItemViewModel(ApartmentStatuses.Complete),
                            new ApartmentDryCleaningStatusListItemViewModel(ApartmentStatuses.Incomplete)
                      };

            return new ApartmentStatusListViewModel(apartmentStatuses);
        }

        public static ApartmentStatusListItemViewModel CompletedStatusViewModel()
        {
            return new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Complete);
        }

        public static ApartmentStatusListItemViewModel InCompleteStatusViewModel()
        {
            return new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Incomplete);
        }
    }
}
