namespace Carlton.Infrastructure.Security
{
    public interface IAuthorizer
    {
        bool IsAuthorized(object instance);
    }
}
