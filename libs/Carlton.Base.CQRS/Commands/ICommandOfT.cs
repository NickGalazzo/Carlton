using MediatR;

namespace Carlton.Base.CQRS.Commands
{
    public interface ICommand<T> : ICommand, IRequest<T>
        where T : ICommandResult
    {
    }
}
