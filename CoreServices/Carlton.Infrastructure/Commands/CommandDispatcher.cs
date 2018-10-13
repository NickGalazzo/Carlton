using System;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Commands
{
    public class CommandDispatcher : BaseDispatcher
    {
        public CommandDispatcher(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<ICommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>) base.ServiceProvider.GetService(typeof(ICommandHandler<TCommand>));

            if (!((handler != null) && handler is ICommandHandler<TCommand>))
            {
                throw new Exception();
            }

            return await handler.ExecuteAsync(command);
        }
    }
}
