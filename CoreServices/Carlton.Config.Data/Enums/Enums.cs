namespace Carlton.Config.Data.Enums
{
    public enum ResourceTypes
    {
        Application = 1,
        Database = 2,
        MessageQueue = 3
    }

    public enum ResourceStatuses
    {
        Active = 1,
        Inactive = 2
    }

    public enum ResourceEnviornments
    {
        Dev = 1,
        Test = 2,
        Prod = 3
    }

    public enum HealthStatuses
    {
        Failed = 0,
        Unhealthy = 1,
        Degraded = 2,
        Healthy = 3,
    }
}
