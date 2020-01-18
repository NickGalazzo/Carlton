using Carlton.Base.Infastructure.Client.Events;
using MediatR;

namespace Carlton.Base.Infastructure.Client.Base
{
    public interface IComponentEventHandler<TEvent, TResult> : IRequestHandler<TEvent, TResult>
        where TEvent : IComponentEvent<TResult>
        where TResult : IComponentEventResult
    {
    }
}

