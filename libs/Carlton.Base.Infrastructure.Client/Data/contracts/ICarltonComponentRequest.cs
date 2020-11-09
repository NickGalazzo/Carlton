using MediatR;

namespace Carlton.Base.Client.Data
{
    public interface ICarltonComponentRequest<TViewModel> : IRequest<TViewModel>
    {
    }
}
