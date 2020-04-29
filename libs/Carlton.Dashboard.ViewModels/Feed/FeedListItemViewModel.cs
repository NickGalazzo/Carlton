
using System;
using System.Globalization;

namespace Carlton.Dashboard.ViewModels.Feed
{
    public class FeedListItemViewModel
    {
        public string Title { get; private set; }
        public string Message { get; private set; }
        public FeedUser User { get; private set; }
        public DateTimeOffset FeedDate { get; private set; }
        public string FeedDisplayDate
        {
            get
            {

                var timeDiff = FeedDate.Subtract(DateTimeOffset.UtcNow);


                if(timeDiff < TimeSpan.FromSeconds(60))
                {
                    return $"moments ago";
                }
                else if(timeDiff < TimeSpan.FromMinutes(60))
                {
                    return $"{timeDiff.TotalMinutes} mins ago";
                }
                else if(timeDiff > TimeSpan.FromHours(1) && timeDiff < TimeSpan.FromHours(2))
                {
                    return "1 hr ago";
                }
                else if(timeDiff >= TimeSpan.FromHours(2) && timeDiff < TimeSpan.FromDays(1))
                {
                    return FeedDate.ToLocalTime().ToString("H:mm tt", new CultureInfo("en-US"));
                }
                else
                {
                    return FeedDate.ToLocalTime().Date.ToString("MMMM dd", new CultureInfo("en-US"));
                }
            }

        }


        public FeedListItemViewModel(string title, string message, FeedUser user, DateTimeOffset feedDate)
        {
            Title = title;
            Message = message;
            User = user;
            FeedDate = feedDate;
        }
    }
}