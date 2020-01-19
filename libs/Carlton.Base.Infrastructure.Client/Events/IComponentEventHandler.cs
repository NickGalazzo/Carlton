using Carlton.Base.Infastructure.Client.Events;
using MediatR;

namespace Carlton.Base.Infastructure.Client.Events
{
    public interface IComponentEventHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
        where TResult : IComponentEventResult
    {
    }
}

