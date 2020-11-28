using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State
{
    public interface ICarltonStateStore
    {
        event Func<object, string, Task> StateChanged;
    }
}
