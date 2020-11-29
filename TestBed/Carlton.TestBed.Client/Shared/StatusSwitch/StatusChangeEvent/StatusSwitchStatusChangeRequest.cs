using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.StatusSwitch
{
    public class StatusSwitchStatusChangeRequest : ComponentEventRequestBase<StatusSwitchStatusChangedEvent>
    {
        public StatusSwitchStatusChangeRequest(object sender, StatusSwitchStatusChangedEvent evt) : base(sender, evt)
        {
        }
    }
}
