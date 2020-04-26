using System.Collections.Generic;
using System.Linq;
using Carlton.Dashboard.ViewModels.Groceries;


namespace Carlton.TestBed.Client.TestViewModels
{
    public static class GroceriesTestViewModels
    {
        public static GroceriesListViewModel DefaultGroceriesListViewModel()
        {
            return new GroceriesListViewModel
            {
                Items = new List<GroceriesListItemViewModel>
                {
                    new GroceriesListItemViewModel(1, "Toilet Paper", 25),
                    new GroceriesListItemViewModel(2, "Paper Towels", 57),
                    new GroceriesListItemViewModel(3, "Dish Soap", 92),
                    new GroceriesListItemViewModel(4, "Swiffers", 36)
                }.OrderBy(o => o.PercentRemaining).ToList()
            };
        }

        public static GroceriesListItemViewModel GroceriesGreenListItemViewModel()
        {
            return DefaultGroceriesListViewModel().Items[1];
        }
    }
}
