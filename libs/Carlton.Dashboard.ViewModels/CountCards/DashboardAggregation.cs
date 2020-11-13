namespace Carlton.Dashboard.ViewModels.CountCards
{
    public class DashboardAggregation
    {
        public int Count { get; private set; }
      
        public DashboardAggregation(int count)
        {
            Count = count;
        }
    }
}
