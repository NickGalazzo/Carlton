﻿using System;

namespace Carlton.Base.Client.Components.Data
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
