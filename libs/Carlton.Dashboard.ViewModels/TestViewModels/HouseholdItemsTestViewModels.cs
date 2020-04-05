using Carlton.Dashboard.ViewModels.HouseholdItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class HouseholdItemsTestViewModels
    {
        public static HouseholdItemsViewModel DefaultHouseholdItemsViewModel()
        {
            return new HouseholdItemsViewModel
            {
                Items = new List<HouseholdItem>
                {
                    new HouseholdItem(1, "Toilet Paper", 25),
                    new HouseholdItem(2, "Paper Towels", 57),
                    new HouseholdItem(3, "Dish Soap", 92),
                    new HouseholdItem(4, "Swiffers", 36)
                }.OrderBy(o => o.PercentRemaining).ToList()
            };
        }
    }
}
