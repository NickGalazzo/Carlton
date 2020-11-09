using MediatR;

namespace Carlton.Base.Client.State.Contracts
{
    public interface IComponentEvent : IRequest
    {
        string EventName { get; }
        object EventParams { get; }
    }
}
