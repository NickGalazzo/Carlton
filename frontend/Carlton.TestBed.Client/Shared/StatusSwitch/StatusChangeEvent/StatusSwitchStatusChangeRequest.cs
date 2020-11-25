using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.StatusSwitch
{
    public class StatusSwitchStatusChangeRequest : ComponentEventRequestBase<StatusSwitchStatusChangedEvent>
    {
        public StatusSwitchStatusChangeRequest(StatusSwitchStatusChangedEvent evt) : base(evt)
        {
        }
    }
}
