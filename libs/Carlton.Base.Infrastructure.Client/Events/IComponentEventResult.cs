using System;

namespace Carlton.Base.Infastructure.Client.Events
{
    public interface IComponentEventResult
    {
        bool Succeded { get; }
        Exception Exception { get; }

    }
}
