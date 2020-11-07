
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

                var timeDiff = DateTimeOffset.UtcNow.Subtract(FeedDate);


                if(timeDiff < TimeSpan.FromSeconds(60))
                {
                    return $"moments ago";
                }
                else if(timeDiff < TimeSpan.FromMinutes(60))
                {
                    return $"{Math.Round(timeDiff.TotalMinutes)} min(s) ago";
                }
                else if(timeDiff > TimeSpan.FromHours(1) && timeDiff < TimeSpan.FromHours(24))
                {
                    return $"{Math.Round(timeDiff.TotalHours)} hr(s) ago";
                }
                else
                {
                    return FeedDate.ToLocalTime().Date.ToString("MMM d", new CultureInfo("en-US"));
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