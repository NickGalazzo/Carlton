using Carlton.CQRS.Commands;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.CQRS.Exceptions
{
    public class CommandException : BaseCarltonException
    {
        private const string ErrMessage = "An error occured in Command {0}";

        ICommand Command { get; }

        public CommandException(ICommand command, Exception innerException)
            :base(string.Format(ErrMessage, nameof(command)), innerException)
        {
            Command = command;
        }
    }
}
