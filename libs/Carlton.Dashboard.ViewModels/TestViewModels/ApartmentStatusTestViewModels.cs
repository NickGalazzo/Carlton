using Carlton.Dashboard.ViewModels.ApartmentStatus;
using System.Collections.Generic;


namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ApartmentStatusTestViewModels
    {
        public static ApartmentStatuses DefaultApartmentStatusViewModel()
        {
            var apartmentStatuses = new List<ApartmentStatus>
                     {
                            new ApartmentStatus(ApartmentStatusName.Garbage, ApartmentStatusValue.Complete),
                            new ApartmentStatus(ApartmentStatusName.Recycle, ApartmentStatusValue.Complete),
                            new ApartmentStatus(ApartmentStatusName.Groceries, ApartmentStatusValue.Complete),
                            new ApartmentStatus(ApartmentStatusName.Cleaning, ApartmentStatusValue.Complete),
                            new ApartmentStatus(ApartmentStatusName.Laundry, ApartmentStatusValue.Complete),
                            new ApartmentStatus(ApartmentStatusName.DryCleaning, ApartmentStatusValue.Incomplete)
                      };

            return new ApartmentStatuses(apartmentStatuses);
        }

        public static ApartmentStatus CompletedStatusViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Garbage, ApartmentStatusValue.Complete);
        }

        public static ApartmentStatus InCompleteStatusViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Garbage, ApartmentStatusValue.Incomplete);
        }

        public static ApartmentStatus GarbageViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Garbage, ApartmentStatusValue.Complete);
        }

        public static ApartmentStatus RecycleViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Recycle, ApartmentStatusValue.Complete);
        }

        public static ApartmentStatus GroceriesViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Groceries, ApartmentStatusValue.Complete);
        }

        public static ApartmentStatus CleaningViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Cleaning, ApartmentStatusValue.Complete);
        }

        public static ApartmentStatus LaundryViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.Laundry, ApartmentStatusValue.Complete);
        }

        public static ApartmentStatus DryCleaningViewModel()
        {
            return new ApartmentStatus(ApartmentStatusName.DryCleaning, ApartmentStatusValue.Complete);
        }
    }
}
