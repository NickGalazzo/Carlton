using System.Collections.Generic;
using System.Linq;
using Carlton.Dashboard.ViewModels.Groceries;


namespace Carlton.TestBed.Client.TestViewModels
{
    public static class GroceriesTestViewModels
    {
        public static Groceries DefaultGroceriesList()
        {
            return new Groceries
            {
                Items = new List<GroceryItem>
                {
                    new GroceryItem(1, "Toilet Paper", 25),
                    new GroceryItem(2, "Paper Towels", 57),
                    new GroceryItem(3, "Dish Soap", 92),
                    new GroceryItem(4, "Swiffers", 36)
                }.OrderBy(o => o.PercentRemaining).ToList()
            };
        }

        public static GroceryItem GroceriesLowListItemViewModel()
        {
            return DefaultGroceriesList().Items.ElementAt(0);
        }

        public static GroceryItem GroceriesMediumListItemViewModel()
        {
            return DefaultGroceriesList().Items.ElementAt(2);
        }

        public static GroceryItem GroceriesHighListItemViewModel()
        {
            return DefaultGroceriesList().Items.ElementAt(3);
        }
    }
}
