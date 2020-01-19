namespace Carlton.Base.CQRS.Commands
{
    public interface ICommandResult
    {
        bool IsSuccess { get; set; } 
    }
}
