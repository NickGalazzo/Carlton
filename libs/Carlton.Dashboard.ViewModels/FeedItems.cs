using System;
using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels
{
    public record FeedItems(IEnumerable<FeedItem> Items);
    public record FeedItem(string Title, string Message, FeedUser User, DateTimeOffset FeedDate);
    public record FeedUser(string UserName, string Avatar);
}



