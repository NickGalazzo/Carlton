namespace Carlton.Base.Client.State
{
    public enum ComponentStatus
    {
        SYNCED = 0,
        SYNCING = 1,
        INVALID = 2
    }

    public interface IStatusComponent
    {
        public ComponentStatus ComponentStatus { get; set; }
    }
}
