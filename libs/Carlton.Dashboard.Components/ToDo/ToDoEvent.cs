using System;
using System.Collections.Generic;
using System.Text;
using Carlton.Base.Infrastructure.Client.Events;

namespace Carlton.Dashboard.Components.ToDo
{
    public class ToDoEvent : IComponentEvent
    {
        public string Test { get; set; }

        public ToDoEvent(string test)
        {
            this.Test = test;
        }
    }

    public class ToDoEventResult: IComponentEventResult
    {
        public string Test { get; set; }

        public bool Succeded { get; }
        public Exception Exception { get; }
    }
}
