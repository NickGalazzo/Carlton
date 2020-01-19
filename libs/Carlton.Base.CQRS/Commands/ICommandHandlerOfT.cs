using MediatR;

namespace Carlton.Base.CQRS.Commands
{
    public interface ICommandHandler<TCommand, TCommandResult> : ICommandHandler, IRequestHandler<TCommand, TCommandResult> 
        where TCommand : ICommand<TCommandResult>
        where TCommandResult : ICommandResult
    {
    }
}
