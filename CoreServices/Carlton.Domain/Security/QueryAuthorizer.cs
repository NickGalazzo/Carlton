﻿using Carlton.Domain.Queries;
using Microsoft.AspNetCore.Http;

namespace Carlton.Domain.Security
{
    public abstract class BaseQueryAuthorizer<T> : BaseAuthorizer<T> where T : IQuery
    {
        protected BaseQueryAuthorizer(IHttpContextAccessor context) : base(context)
        {
        }
    }
}