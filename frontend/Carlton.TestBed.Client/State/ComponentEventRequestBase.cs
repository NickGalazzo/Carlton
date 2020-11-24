using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client.State
{
    public abstract class ComponentEventRequestBase<TComponentEvent> : ICarltonComponentEventRequest<TComponentEvent>
        where TComponentEvent : ICarltonComponentEvent
    {
        public TComponentEvent ComponentEvent { get; private set; }

        public ComponentEventRequestBase(TComponentEvent evt)
        {
            ComponentEvent = evt;
        }
    }
}
