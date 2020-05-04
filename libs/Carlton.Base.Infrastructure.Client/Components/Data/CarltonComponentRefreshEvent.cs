using System;

namespace Carlton.Base.Client.Components.Data
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
