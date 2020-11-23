using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonViewModelRequestHandler<TViewModel> : IRequestHandler<ICarltonViewModelRequest<TViewModel>, TViewModel>
    {
    }
}
