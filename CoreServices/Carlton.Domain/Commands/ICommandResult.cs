namespace Carlton.Domain.Commands
{
    public interface ICommandResult
    {
        bool IsSuccess { get; set; } 
    }
}
