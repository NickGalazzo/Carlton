using MediatR;

namespace Carlton.Domain.Commands
{
    public interface ICommand : IRequest<ICommandResult>
    {
    }
}
