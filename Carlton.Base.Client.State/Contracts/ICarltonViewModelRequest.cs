using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonViewModelRequest<TViewModel> : IRequest<TViewModel>
    {
    }
}

