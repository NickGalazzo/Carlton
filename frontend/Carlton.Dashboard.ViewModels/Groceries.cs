using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels
{
    public record Groceries(IEnumerable<GroceryItem> Items);
    public record GroceryItem(int Id, string Name, double PercentRemaining);
}
