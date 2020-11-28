using System.Collections.Generic;

namespace Carlton.TestBed.Client.Shared.EventConsole
{
    public record EventConsoleViewModel(IEnumerable<object> ComponentEvents);   
}
