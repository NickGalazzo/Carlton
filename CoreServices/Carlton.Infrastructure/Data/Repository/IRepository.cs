namespace Carlton.Infrastructure.Data.Repository
{
    public interface IRepository<T, IdType> : IReadOnlyRepository<T, IdType>
    {
        void Update(T entity);
        void Insert(T entity);
        void Delete(T entity);
    }
}
