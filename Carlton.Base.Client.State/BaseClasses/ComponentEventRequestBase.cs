namespace Carlton.Base.Client.State
{
    public class ComponentEventRequestBase<TComponentEvent> : ICarltonComponentEventRequest<TComponentEvent>
    {
        public object Sender { get; init; }
        public TComponentEvent ComponentEvent { get; init; }

        public ComponentEventRequestBase(object sender, TComponentEvent evt)
        {
            Sender = sender;
            ComponentEvent = evt;
        }
    }
}
