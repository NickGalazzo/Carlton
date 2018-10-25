using MediatR;

namespace Carlton.Domain.Queries
{
    public interface IQuery<T> : IQuery, IRequest<T> 
        where T : IQueryResult
    {
    }
}
