using System;
using System.Collections.Generic;
using System.Text;
using Carlton.Base.Infrastructure.Client.Events;

namespace Carlton.Dashboard.Components.ToDo
{
    public class ToDoEvent : IComponentEvent
    {
        public string EventName { get; set; }

        public object EventParams { get; set; }

        public ToDoEvent(string eventName, object eventParams)
        {
            EventName = eventName;
            EventParams = eventParams;
        }
    }

    public class ToDoEventResult: IComponentEventResult
    {
        public string Test { get; set; }

        public bool Succeded { get; }
        public Exception Exception { get; }
    }
}
