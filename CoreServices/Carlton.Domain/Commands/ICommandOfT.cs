using MediatR;

namespace Carlton.Domain.Commands
{
    public interface ICommand<T> : ICommand, IRequest<T>
        where T : ICommandResult
    {
    }
}
