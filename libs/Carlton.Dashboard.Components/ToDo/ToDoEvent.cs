using System;
using System.Collections.Generic;
using System.Text;
using Carlton.Base.Infrastructure.Client.Events;
using Carlton.Dashboard.ViewModels.ToDos;
using MediatR;

namespace Carlton.Dashboard.Components.ToDo
{
    public class ToDoEvent : IToDoCompletedRequest
    {
        public int CompletedToDoId { get; private set; }

        public string EventName => nameof(ToDoEvent);

        public ToDoEvent(int completedToDoId)
        {
            CompletedToDoId = completedToDoId;
        }
    }

    public interface IToDoCompletedRequest: IRequest<ToDoListViewModel>
    {
    }
}
