using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectNodeRequestHandler : IRequestHandler<NavTreeSelectNodeRequest, Unit>
    {
        readonly TestBedState _state;

        public NavTreeSelectNodeRequestHandler(TestBedState state)
        {
            _state = state;
        }

        Task<Unit> IRequestHandler<NavTreeSelectNodeRequest, Unit>.Handle(NavTreeSelectNodeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
