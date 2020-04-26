namespace Carlton.Dashboard.ViewModels.Groceries
{
    public class GroceriesListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PercentRemaining { get; set; }

        public GroceriesListItemViewModel(int id, string name, double percentRemaining)
        {
            Id = id;
            Name = name;
            PercentRemaining = percentRemaining;
        }
    }
}
