﻿using MediatR;

namespace Carlton.Base.CQRS.Queries
{
    public interface IQueryHandler<TQuery, TQueryResult> : IQueryHandler, IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
    }
}