using MediatR;

namespace Carlton.CQRS.Queries
{
    public interface IQuery<T> : IQuery, IRequest<T> 
        where T : IQueryResult
    {
    }
}
