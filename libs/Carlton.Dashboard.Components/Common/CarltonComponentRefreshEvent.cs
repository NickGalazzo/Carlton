using System;

namespace Carlton.Dashboard.Components.Common
{
    public class CarltonComponentRefreshEvent<TViewModel>
    {
        public Type Type { get; set; }

        public CarltonComponentRefreshEvent()
        {
            Type = typeof(TViewModel);
        }
    }
}
