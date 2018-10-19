using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Domain.Commands
{
    public interface ICommandResult
    {
        bool IsSuccess { get; set; } 
    }
}
