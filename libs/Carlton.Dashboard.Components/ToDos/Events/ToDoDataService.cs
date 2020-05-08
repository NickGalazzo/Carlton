using Carlton.Base.Infrastructure.Client.Data;
using MediatR;

namespace Carlton.Dashboard.Components.ToDo
{
    public class ToDoDataService : BaseDataService<ToDoDataService>
    {
        public ToDoDataService(IMediator mediator) : base(mediator)
        {
        }
    }
}
