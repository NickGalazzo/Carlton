namespace Carlton.Domain.Security
{
    public interface IAuthorizer
    {
        bool IsAuthorized(object instance);
    }
}
