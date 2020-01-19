using System;

namespace Carlton.Base.Infrastructure.Client.Events
{
    public interface IComponentEventResult
    {
        bool Succeded { get; }
        Exception Exception { get; }

    }
}
