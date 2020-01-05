namespace Carlton.Dashboard.ViewModels.Feed
{
    public class FeedUser
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }

        public FeedUser(string userName, string avatar)
        {
            UserName = userName;
            Avatar = avatar;
        }
    }
}
