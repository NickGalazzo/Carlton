using Carlton.Base.Client.Status;
using Carlton.TestBed.TestBedNavTree;
using System;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.State
{
    public class CarltonTestBedState
    {
        public IEnumerable<TestBedNavTreeItem> TreeItems { get; private set; }
        public Type TestComponentType { get; private set; }
        public bool IsTestComponentCarltonComponent { get; private set; }
        public ComponentStatus TestComponentStatus { get; private set; }
        public object TestComponentViewModel { get; private set; }
        public IList<object> ComponentEvents { get; private set; }
    }
}





