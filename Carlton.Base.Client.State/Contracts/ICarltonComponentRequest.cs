using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonComponentRequest<TViewModel> : IRequest<TViewModel>
    {
    }
}
