using Carlton.Base.Client.State;
using Carlton.Base.Client.Status;

namespace Carlton.TestBed.Client.Shared.StatusSwitch.Models
{
    public class StatusSwitchStatusChangedEvent : ICarltonComponentEvent
    {
        public ComponentStatus ComponentStatus { get; set; }
        public string EventName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public object EventData { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}

