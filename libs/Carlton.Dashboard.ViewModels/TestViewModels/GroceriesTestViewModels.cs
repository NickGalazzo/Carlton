using System.Collections.Generic;
using System.Linq;

namespace Carlton.Dashboard.ViewModels.TestViewModels
{
    public static class GroceriesTestViewModels
    {
        public static Groceries DefaultGroceriesListViewModel()
        {
            return new Groceries
                (
                    new List<GroceryItem>
                    {
                        new GroceryItem(1, "Toilet Paper", 25),
                        new GroceryItem(2, "Paper Towels", 57),
                        new GroceryItem(3, "Dish Soap", 92),
                        new GroceryItem(4, "Swiffers", 36)
                    }.OrderBy(o => o.PercentRemaining)
                );
        }

        public static GroceryItem GroceriesLowListItemViewModel()
        {
            return DefaultGroceriesListViewModel().Items.ElementAt(0);
        }

        public static GroceryItem GroceriesMediumListItemViewModel()
        {
            return DefaultGroceriesListViewModel().Items.ElementAt(2);
        }

        public static GroceryItem GroceriesHighListItemViewModel()
        {
            return DefaultGroceriesListViewModel().Items.ElementAt(3);
        }
    }
}

