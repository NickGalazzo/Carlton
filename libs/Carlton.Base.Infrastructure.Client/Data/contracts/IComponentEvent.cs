using MediatR;

namespace Carlton.Base.Client.Data
{
    public interface IComponentEvent : IRequest
    {
        string EventName { get; }
        object EventParams { get; }
    }
}
