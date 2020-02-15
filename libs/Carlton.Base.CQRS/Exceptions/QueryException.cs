﻿using Carlton.Base.CQRS.Queries;
using Carlton.Base.Infrastructure.Exceptions;
using System;

namespace Carlton.Base.CQRS.Exceptions
{
    public class QueryException : CarltonBaseException
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