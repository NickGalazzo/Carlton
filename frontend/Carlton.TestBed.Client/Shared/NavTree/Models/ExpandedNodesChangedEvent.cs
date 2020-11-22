using Carlton.Base.Client.State.Contracts;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.NavTree.Models
{
    public class ExpandedNodesChangedEvent : ICarltonComponentEvent
    {
        public IEnumerable<TestBedNavTreeItem> ExpandedNodes { get; set; }

        public string EventName => throw new System.NotImplementedException();

        public ExpandedNodesChangedEvent(IEnumerable<TestBedNavTreeItem> expandedNodes)
        {
            ExpandedNodes = expandedNodes;
        }
    }
}
