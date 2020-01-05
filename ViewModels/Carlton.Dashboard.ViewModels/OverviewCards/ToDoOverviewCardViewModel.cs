
namespace Carlton.Dashboard.ViewModels.OverviewCards
{
    public class ToDoOverviewCardViewModel
    {
        public int OpenToDoCount { get; set; }

        public ToDoOverviewCardViewModel(int openToDoCount)
        {
            OpenToDoCount = openToDoCount;
        }
    }
}
