using System;

namespace Carlton.Dashboard.Components.Common.Events
{
    public class CarltonComponentDetailViewNavigationEvent<TViewModel>
    {
        public Type Type { get; set; }

        public CarltonComponentDetailViewNavigationEvent()
        {
            Type = typeof(TViewModel);
        }
    }
}
