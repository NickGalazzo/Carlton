namespace Carlton.Base.Client.State
{
    public class ComponentEventRequestBase<TComponentEvent> : ICarltonComponentEventRequest<TComponentEvent>
    {
        public TComponentEvent ComponentEvent { get; private set; }

        public ComponentEventRequestBase(TComponentEvent evt)
        {
            ComponentEvent = evt;
        }
    }
}
