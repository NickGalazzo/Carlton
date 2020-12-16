using System;
using System.Collections.Generic;

namespace Carlton.Base.Client.State
{
    public class CarltonStateEventMapBuiler
    {
        private readonly IList<CarltonComponentStateEvents> _componentStateEvenets
            = new List<CarltonComponentStateEvents>();

        public CarltonStateEventMapBuiler ForComponent<TViewModel>(Action<EventListBuider> builder)
        {
            var eb = new EventListBuider();
            builder(eb);
            _componentStateEvenets.Add(new CarltonComponentStateEvents(typeof(TViewModel), eb.Build()));
            return this;
        }

        public IEnumerable<CarltonComponentStateEvents> Build()
        {
            return _componentStateEvenets;
        }

        public class EventListBuider
        {
            private readonly IList<string> _stateEvents = new List<string>();

            public void AddStateEvent(string stateEvent)
            {
                _stateEvents.Add(stateEvent);
            }

            public IEnumerable<string> Build()
            {
                return _stateEvents;
            }
        }
    }
}
