using Carlton.Domain.Base;
using Carlton.Domain.Queries;
using System;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Commands
{
    public class QueryDispatcher : BaseDispatcher
    {
        public QueryDispatcher(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery
                                                                                     where TQueryResult : IQueryResult
        {
            var handler = (IQueryHandler<TQuery, TQueryResult>)base.ServiceProvider.GetService(typeof(IQueryHandler<TQuery, TQueryResult>));

            if (!((handler != null) && handler is IQueryHandler<TQuery, TQueryResult>))
            {
                throw new Exception();
            }

            return (TQueryResult)(await handler.ExecuteAsync(query));
        }
    }
}



