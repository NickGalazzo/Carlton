using Carlton.Domain.Commands;
using System;

namespace Carlton.Domain.Exceptions
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

        public CommandException(ICommand command, string message, Exception innerException) : base(message, innerException)
        {
            Command = command;
        }
    }
}
