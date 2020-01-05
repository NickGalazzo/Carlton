using System;

namespace Carlton.Config.Data.Models.Health
{
    public class HealthStatusResult
    {
        public DateTimeOffset TimeStamp { get; set; }
        public int ResourceId { get; set; }
        public HealthStatus HealthStatus { get; set; }
    }
}
