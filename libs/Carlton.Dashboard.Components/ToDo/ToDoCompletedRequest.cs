using Carlton.Base.Infrastructure.Client.Events;
using Carlton.Dashboard.ViewModels.ToDos;
using MediatR;

namespace Carlton.Dashboard.Components.ToDo
{
    public class ToDoCompletedRequest : IRequest<ToDoListViewModel>
    {
        public int CompletedToDoId { get; set; }

        public ToDoCompletedRequest(int completedToDoId)
        {
            CompletedToDoId = completedToDoId;
        }
    }
}
