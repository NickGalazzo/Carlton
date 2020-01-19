namespace Carlton.CQRS.Commands
{
    public interface ICommandResult
    {
        bool IsSuccess { get; set; } 
    }
}
