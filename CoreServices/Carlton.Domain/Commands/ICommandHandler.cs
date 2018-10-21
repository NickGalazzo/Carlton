using MediatR;

namespace Carlton.Domain.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, ICommandResult> where TCommand : ICommand 
    {
    }
}
