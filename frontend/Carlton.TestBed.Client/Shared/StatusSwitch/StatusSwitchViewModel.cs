using Carlton.Base.Client.Status;

namespace Carlton.TestBed.Client.Shared.StatusSwitch
{
    public class StatusSwitchViewModel
    {
        public ComponentStatus TestComponentStatus { get; }

        public StatusSwitchViewModel(ComponentStatus testComponentStatus)
        {
            TestComponentStatus = testComponentStatus;
        }
    }
}
