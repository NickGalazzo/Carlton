using Carlton.CQRS.Queries;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.CQRS.Exceptions
{
    public class QueryException : BaseCarltonException
    {
        public IQuery Query { get; }

        private const string ErrMessage = "An error occured in Query {0}";

        public QueryException(IQuery query, Exception innerException)
            : base(string.Format(ErrMessage, nameof(query)), innerException)
        {
            Query = query;
        }
    }
}
