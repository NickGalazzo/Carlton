using System.Collections.Generic;
using Carlton.Base.Client.State.Contracts;

namespace Carlton.TestBed.Client.Shared.EventConsole.Models
{
    public class TestBedEventConsoleViewModel 
    {
        public IEnumerable<object> ComponentEvents { get; set; }
    }
}
