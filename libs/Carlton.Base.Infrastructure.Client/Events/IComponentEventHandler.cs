using MediatR;

namespace Carlton.Base.Infrastructure.Client.Events
{
    public interface IComponentEventHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
        where TResult : IComponentEventResult
    {
    }
}

