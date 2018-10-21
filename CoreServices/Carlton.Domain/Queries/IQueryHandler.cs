using MediatR;
using System.Threading.Tasks;

namespace Carlton.Domain.Queries
{
    public interface IQueryHandler : IRequestHandler<IQuery, IQueryResult>
    {
    }
}
