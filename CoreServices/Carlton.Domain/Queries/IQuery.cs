using MediatR;

namespace Carlton.Domain.Queries
{
    public interface IQuery : IRequest<IQueryResult> 
    {
    }
}
