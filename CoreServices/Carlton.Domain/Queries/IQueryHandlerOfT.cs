using MediatR;

namespace Carlton.Domain.Queries
{
    public interface IQueryHandler<TQuery, TQueryResult> : IQueryHandler, IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
    }
}
