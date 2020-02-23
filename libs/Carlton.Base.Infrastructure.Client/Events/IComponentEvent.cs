﻿using MediatR;

namespace Carlton.Base.Infrastructure.Client.Events
{
    public interface IComponentEvent//<T> : IRequest<T>
     //   where T : IComponentEventResult
    {
        string EventName { get; }
        object EventParams { get; }
    }
}
