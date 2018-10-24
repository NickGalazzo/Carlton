using Carlton.Domain.Queries;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.Domain.Exceptions
{
    public class QueryException : BaseCarltonException
    {
        public IQuery Query { get; }

        public QueryException(IQuery query)
        {
            Query = query;
        }

        public QueryException(IQuery query, string message) : base(message)
        {
            Query = query;
        }

        public QueryException(IQuery query, string message, Exception innerException) : base(message, innerException)
        {
            Query = Query;
        }

    }
}
