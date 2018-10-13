using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Infrastructure.Commands
{
    public interface ICommandResult
    {
        bool IsSuccess { get; set; } 
    }
}
