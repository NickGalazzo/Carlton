using MediatR;

namespace Carlton.Base.Client.Events
{
    public interface IComponentEventHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
        where TResult : IComponentEventResult
    {
    }
}

