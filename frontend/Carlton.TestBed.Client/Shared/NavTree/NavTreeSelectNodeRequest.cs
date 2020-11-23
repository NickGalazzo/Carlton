using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectNodeRequest : ComponentEventRequestBase<NavTreeSelectedNodeChangedEvent>
    {
        public NavTreeSelectNodeRequest(NavTreeSelectedNodeChangedEvent componentEvent)
            :base(componentEvent)
        {
        }
    }
}
