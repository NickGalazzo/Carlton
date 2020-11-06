using Carlton.Dashboard.ViewModels.ToDos;
using MediatR;

namespace Carlton.Dashboard.Components.ToDo.Events
{
    public class ToDoStatusChangedEvent : IRequest<ToDoListViewModel>
    {
        public int ToDoID { get; }
        public bool ToDoCompleted { get; }

        public ToDoStatusChangedEvent(int toDoID, bool toDoCompleted)
        {
            ToDoID = toDoID;
            ToDoCompleted = toDoCompleted;
        }
    }
}
