using System;

namespace Carlton.Domain.Base
{
    public abstract class BaseDispatcher
    {
        protected readonly IServiceProvider ServiceProvider;

        internal BaseDispatcher(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
