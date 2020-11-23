using Carlton.Base.Client.State;
using Carlton.Base.Client.State.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.State
{
    public class ComponentEventRequestBase<TComponentEvent> : ICarltonComponentEventRequest<TComponentEvent>
        where TComponentEvent : ICarltonComponentEvent
    {
        public TComponentEvent ComponentEvent { get; private set; }

        public ComponentEventRequestBase(TComponentEvent evt)
        {
            ComponentEvent = evt;
        }
    }
}
