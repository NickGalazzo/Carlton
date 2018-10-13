using System;

namespace Carlton.Infrastructure
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
