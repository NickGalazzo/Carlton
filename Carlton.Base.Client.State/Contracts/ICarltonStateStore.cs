using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonStateStore
    {
        event Action<object, string> StateChanged;
    }
}
