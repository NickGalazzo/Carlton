using System;
using Carlton.Base.Client.State;

namespace Carlton.Dashboard.Components.Common.Events
{
    public class CarltonComponentRefreshEvent<TViewModel> : ICarltonComponentEvent
    {
        public string EventName => throw new NotImplementedException();
    }
}
