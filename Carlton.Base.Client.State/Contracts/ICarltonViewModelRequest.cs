using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonViewModelRequest<TVIewModel> : IRequest<TVIewModel>
    {
    }
}
