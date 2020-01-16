using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Client.Base.Events
{
    public interface IComponentEventHandler<TEvent, TResult> : IRequestHandler<TEvent, TResult>
        where TEvent : IComponentEvent<TResult>
        where TResult : IComponentEventResult
    {
    }
}

