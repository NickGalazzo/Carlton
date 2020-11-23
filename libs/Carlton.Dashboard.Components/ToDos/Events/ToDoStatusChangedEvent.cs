using Carlton.Base.Client.State.Components;
using Carlton.Base.Client.State;

namespace Carlton.Dashboard.Components.ToDos.Events
{
    public class ToDoStatusChangedEvent : ICarltonComponentEvent
    {
        public int ToDoID { get; }
        public bool ToDoCompleted { get; }
        public string EventName => "";

        public ToDoStatusChangedEvent(int toDoID, bool toDoCompleted)
        {
            ToDoID = toDoID;
            ToDoCompleted = toDoCompleted;
        }
    }
}
