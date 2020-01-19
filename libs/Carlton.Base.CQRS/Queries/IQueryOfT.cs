using MediatR;

namespace Carlton.Base.CQRS.Queries
{
    public interface IQuery<T> : IQuery, IRequest<T> 
        where T : IQueryResult
    {
    }
}
