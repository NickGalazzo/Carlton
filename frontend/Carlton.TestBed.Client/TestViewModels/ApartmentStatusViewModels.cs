using Carlton.Dashboard.ViewModels.ApartmentStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ApartmentStatusViewModels
    {
        public static ApartmentStatusesViewModel DefaultApartmentStatusViewModel()
        {
            return new ApartmentStatusesViewModel()
            {
                Statuses = new List<ApartmentStatus>
                     {
                            new ApartmentStatus("Garbage", ApartmentStatuses.Complete, "mdi-delete"),
                            new ApartmentStatus("Recycle", ApartmentStatuses.Complete, "mdi-recycle"),
                            new ApartmentStatus("Shopping", ApartmentStatuses.Complete, "mdi-cart"),
                            new ApartmentStatus("Cleaning", ApartmentStatuses.Complete, "mdi-spray-bottle"),
                            new ApartmentStatus("Laundry", ApartmentStatuses.Complete, "mdi-washing-machine"),
                            new ApartmentStatus("Dry Cleaning", ApartmentStatuses.Incomplete, "mdi-tie")
                             }
            };
        }
    }
}
