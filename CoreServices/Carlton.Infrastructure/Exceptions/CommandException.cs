using Carlton.Infrastructure.Commands;
using System;

namespace Carlton.Infrastructure.Exceptions
{
    public class CommandException : Exception
    {
        ICommand Command { get; }

        public CommandException(ICommand command)
        {
            Command = command;
        }

        public CommandException(ICommand command, string message) : base(message)
        {
            Command = command;
        }

        public CommandException(ICommand command, string message, RemoteServiceException innerException) : base(message, innerException)
        {
            Command = command;
        }
    }
}
