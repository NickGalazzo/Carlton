using Carlton.Dashboard.ViewModels.ToDos;
using MediatR;

namespace Carlton.Dashboard.Components.ToDo.Events
{
    public class ToDoStatusChangedEvent : IRequest<ToDoListViewModel>
    {
        public int CompletedToDoId { get; }
        public bool ToDoCompleted { get; }

        public ToDoStatusChangedEvent(int completedToDoId, bool toDoCompleted)
        {
            CompletedToDoId = completedToDoId;
            ToDoCompleted = toDoCompleted;
        }
    }
}
