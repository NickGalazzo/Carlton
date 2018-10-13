using System.Threading.Tasks;

namespace Carlton.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<ICommandResult> ExecuteAsync(ICommand command);
    }
}
