using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonRequestFactory
    {
        IRequest<Unit> GetComponentEventRequest<TComponentEvent>(ICarltonComponentEvent evt)
              where TComponentEvent : ICarltonComponentEvent;
        IRequest<TViewModel> GetViewModelRequest<TViewModel>();
    }
}
