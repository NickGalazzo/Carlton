using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carlton.Base.Infrastructure.Client.Events;

namespace Carlton.Base.Infrastructure.Client.Components.TestBed
{
    public class TestBedService
    {
        public delegate void ComponentEventFiredHandler(IComponentEvent evt);
        public event EventHandler<IComponentEvent> ComponentEventFired;

        public void FireEvent(object sender, IComponentEvent evt)
        {
            ComponentEventFired.Invoke(sender, evt);
        }
    }
}
