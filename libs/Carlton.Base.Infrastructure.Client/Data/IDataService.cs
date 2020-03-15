

using Carlton.Base.Infrastructure.Client.Events;
using MediatR;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Client.Data
{
    public interface IDataService<TViewModel> : IReadOnlyDataService<TViewModel>
    {
        Task HandleComponentEvent(IRequest<TViewModel> evt);
    }
}
