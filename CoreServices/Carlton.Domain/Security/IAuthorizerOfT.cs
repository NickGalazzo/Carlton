namespace Carlton.Domain.Security
{
    public interface IAuthorizer<in T> : IAuthorizer
    {
        bool IsAuthorized(T instance);
    }
}
