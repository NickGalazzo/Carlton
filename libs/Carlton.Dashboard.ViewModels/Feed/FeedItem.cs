namespace Carlton.Dashboard.ViewModels.Feed
{
    public class FeedItem
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public FeedUser User { get; set; }

        public FeedItem(string title, string message, FeedUser user)
        {
            Title = title;
            Message = message;
            User = user;
        }
    }
}