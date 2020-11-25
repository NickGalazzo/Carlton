using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonComponentEventRequest<TComponentEvent> : IRequest<Unit>
    {
        TComponentEvent ComponentEvent { get; }
    }
}
