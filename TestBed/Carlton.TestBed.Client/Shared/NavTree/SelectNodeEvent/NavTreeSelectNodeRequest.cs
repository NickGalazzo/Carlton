using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectNodeRequest : ComponentEventRequestBase<NavTreeSelectedNodeEvent>
    {
        public NavTreeSelectNodeRequest(object sender, NavTreeSelectedNodeEvent componentEvent)
            :base(sender, componentEvent)
        {
        }
    }
}
