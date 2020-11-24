using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonComponentEventRequest<TComponentEvent> : IRequest<Unit>
        where TComponentEvent : ICarltonComponentEvent
    {
        TComponentEvent ComponentEvent { get; }
    }
}
