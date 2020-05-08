using System;

namespace Carlton.Dashboard.Components.Common.Events
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
