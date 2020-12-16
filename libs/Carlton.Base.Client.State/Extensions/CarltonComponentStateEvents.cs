using System;
using System.Collections.Generic;

namespace Carlton.Base.Client.State
{
    public class CarltonComponentStateEvents : IEnumerable<string>
    {
        private readonly IEnumerable<string> _stateEvents;

        public Type ViewModelType { get; init; }


        public CarltonComponentStateEvents(Type viewModelType, IEnumerable<string> stateEvents)
        {
            ViewModelType = viewModelType;
            _stateEvents = stateEvents;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _stateEvents.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _stateEvents.GetEnumerator();
        }
    }

}
