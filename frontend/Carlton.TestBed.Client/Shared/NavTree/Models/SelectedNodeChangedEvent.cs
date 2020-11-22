using Carlton.Base.Client.State.Contracts;

namespace Carlton.TestBed.Client.Shared.NavTree.Models
{
    public class SelectedNodeChangedEvent : ICarltonComponentEvent
    {
        public string NodeName { get; }
        public string EventName => TestBedRequestMapper.SELECTED_NODE_CHANGED;

        public SelectedNodeChangedEvent(string nodeName)
        {
            NodeName = nodeName;
        }
    }
}
