using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonComponentEventRequest<TComponentEvent> : IRequest<Unit>
    {
        object Sender { get; }
        TComponentEvent ComponentEvent { get; }
    }
}
