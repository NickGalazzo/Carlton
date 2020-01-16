using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Client.Base.Events
{
    public interface IComponentEventResult
    {
        bool Succeded { get; }
        Exception Exception { get; }

    }
}
