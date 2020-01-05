namespace Carlton.Dashboard.ViewModels.HouseholdItems
{
    public class HouseholdItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PercentRemaining { get; set; }

        public HouseholdItem(int id, string name, double percentRemaining)
        {
            Id = id;
            Name = name;
            PercentRemaining = percentRemaining;
        }
    }
}
