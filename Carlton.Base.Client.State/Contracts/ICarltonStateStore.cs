using System;

namespace Carlton.Base.Client.State
{
    public interface ICarltonStateStore
    {
        event Action<object, string> StateChanged;
    }
}
