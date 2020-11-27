using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonRequestFactory
    {
        IRequest<Unit> GetComponentEventRequest(object sender, object evt);
        IRequest<TViewModel> GetViewModelRequest<TViewModel>();
    }
}
