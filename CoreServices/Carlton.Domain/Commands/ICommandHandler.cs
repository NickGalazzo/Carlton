using System.Threading.Tasks;

namespace Carlton.Domain.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<ICommandResult> ExecuteAsync(ICommand command);
    }
}
