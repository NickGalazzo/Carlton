using System;

namespace Carlton.Dashboard.ViewModels.Feed
{
    public class FeedItem
    {
        public string Title { get; private set; }
        public string Message { get; private set; }
        public FeedUser User { get; private set; }
        public DateTimeOffset FeedDate { get; private set; }
      

        public FeedItem(string title, string message, FeedUser user, DateTimeOffset feedDate)
        {
            Title = title;
            Message = message;
            User = user;
            FeedDate = feedDate;
        }
    }
}

