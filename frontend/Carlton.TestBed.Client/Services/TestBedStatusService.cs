using Carlton.Base.Client.Enums;

namespace Carlton.TestBed.Client.Services
{
    public class TestBedStatusService
    {
        public ComponentStatus TestComponentStatus { get; private set; }

        public void UpdateComponentStatus(ComponentStatus status)
        {
            TestComponentStatus = status;
        }
    }
}
