using MediatR;

namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonComponentRequest<TViewModel> : IRequest<TViewModel>
    {
    }

    public interface IGetViewModelRequest<TViewModel> : ICarltonComponentRequest<TViewModel>
    {
    }
}
