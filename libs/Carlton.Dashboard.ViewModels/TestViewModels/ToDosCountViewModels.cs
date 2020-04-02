using Carlton.Dashboard.ViewModels.CountCards;

namespace Carlton.Dashboard.ViewModels.TestViewModels
{
    public static class ToDosCountViewModels
    {
        public static CarltonBaseCountCardViewModel DefaultToDoListViewModel()
        {
            return new ToDosCountCardViewModel(7);
        }
    }
}
