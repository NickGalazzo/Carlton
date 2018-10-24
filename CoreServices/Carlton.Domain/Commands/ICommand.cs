using MediatR;

namespace Carlton.Domain.Commands
{
    public interface ICommand<T> : IRequest<T>
        where T : ICommandResult
    {
    }
}
