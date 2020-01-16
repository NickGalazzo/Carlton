using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Client.Base.Events
{
    public interface IComponentEvent<T> : IRequest<T>
        where T : IComponentEventResult
    {
    }
}
