using Carlton.Config.Data.Enums;

namespace Carlton.Config.Data.Models.Config
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Url { get; set; }
        public string IpAddress { get; set; }
        public ResourceTypes ResourceType { get; set; }
        public ResourceStatuses ResourceStatus { get; set; } 
        public ResourceEnviornments ResourceEnviornment { get; set; }
    }
}
