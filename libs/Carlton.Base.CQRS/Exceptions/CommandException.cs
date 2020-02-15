using Carlton.Base.CQRS.Commands;
using Carlton.Base.Infrastructure.Exceptions;
using System;

namespace Carlton.Base.CQRS.Exceptions
{
    public class CommandException : CarltonBaseException
    {
        private const string ErrMessage = "An error occured in Command {0}";

        ICommand Command { get; }

        public CommandException(ICommand command, Exception innerException)
            :base(string.Format(new System.Globalization.CultureInfo("en-US"),
                                ErrMessage, nameof(command)), innerException)
        {
            Command = command;
        }
    }
}
