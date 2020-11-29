using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.Shared.ComponentViewer
{
    public class ComponentViewerAddEventRequest : ComponentEventRequestBase<ComponentViewerAddEvent>
    {
        public ComponentViewerAddEventRequest(object sender, ComponentViewerAddEvent evt) : base(sender, evt)
        {
        }
    }
}
