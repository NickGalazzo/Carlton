using System;

namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonDataStore
    {
        event EventHandler StateChanged;
        void Mutate(object mutation);
        object State { get; }
    }
}
