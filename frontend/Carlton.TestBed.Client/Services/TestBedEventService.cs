using System.Collections.Generic;

namespace Carlton.TestBed
{
    public class TestBedEventService
    {
        public IList<object> ComponentEvents { get; private set; }

        public TestBedEventService()
        {
            ComponentEvents = new List<object>();
        }
       
        public void AddComponentEvent(object evt)
        {
            ComponentEvents.Add(evt);
        }

        public void ClearEvents()
        {
            ComponentEvents.Clear();
        }
    }
}
