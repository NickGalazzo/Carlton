using System.Threading.Tasks;

namespace Carlton.Domain.Queries
{
    public interface IQueryHandler<in T, TResult> where T : IQuery
                                                  where TResult : IQueryResult
    {
        Task<IQueryResult> ExecuteAsync(IQuery query);
    }
}
