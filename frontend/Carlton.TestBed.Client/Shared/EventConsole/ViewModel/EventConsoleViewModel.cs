using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.EventConsole
{
    public class EventConsoleViewModel 
    {
        public IEnumerable<object> ComponentEvents { get; private set; }

        public EventConsoleViewModel(IEnumerable<object> events) => ComponentEvents = events;
    }
}
