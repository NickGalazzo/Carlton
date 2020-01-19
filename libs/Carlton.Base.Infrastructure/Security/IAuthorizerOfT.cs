namespace Carlton.Infrastructure.Security
{
    public interface IAuthorizer<in T> : IAuthorizer
    {
        bool IsAuthorized(T instance);
    }
}
