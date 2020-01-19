using MediatR;

namespace Carlton.CQRS.Commands
{
    public interface ICommand<T> : ICommand, IRequest<T>
        where T : ICommandResult
    {
    }
}
