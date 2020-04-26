using Carlton.Base.Infrastructure.Data;
using Carlton.Dashboard.ViewModels.ToDos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.Dashboard.Components.ToDo
{
    public class ToDoCompletedEventHandler : IRequestHandler<ToDoStatusChangedEvent, ToDoListViewModel>
    {
        public Task<ToDoListViewModel> Handle(ToDoStatusChangedEvent request, CancellationToken cancellationToken)
        {
            //Update server
            //_http.Post($"/CompleteEvent/{evt.ToDoId}");

            //Get New Data From Server
            //var newEvt = _http.Get($"/CompleteEvent/{evt.ToDoId}");


            return null;// Task.FromResult(new ToDoListViewModel());
        }
    }
}
