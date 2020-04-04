using System;

namespace Carlton.Base.Client.Events
{
    public interface IComponentEventResult
    {
        bool Succeded { get; }
        Exception Exception { get; }

    }
}
