using MediatR;

namespace Carlton.Domain.Queries
{
    public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
    }
}
