using MediatR;

namespace Carlton.Domain.Commands
{
    public interface ICommandHandler<TCommand, TCommandResult> : ICommandHandler, IRequestHandler<TCommand, TCommandResult> 
        where TCommand : ICommand<TCommandResult>
        where TCommandResult : ICommandResult
    {
    }
}
