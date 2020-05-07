using System;

namespace Carlton.Dashboard.Components.Common
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
