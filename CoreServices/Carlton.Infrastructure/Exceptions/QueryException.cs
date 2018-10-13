using Carlton.Infrastructure.Queries;
using System;

namespace Carlton.Infrastructure.Exceptions
{
    public class QueryException : Exception
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

        public QueryException(string message, RemoteServiceException innerException) : base(message, innerException)
        {
            Query = Query;
        }

    }
}
