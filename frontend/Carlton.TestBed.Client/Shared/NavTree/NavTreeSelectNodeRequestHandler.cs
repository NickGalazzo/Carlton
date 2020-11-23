using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectNodeRequestHandler : IRequestHandler<NavTreeSelectNodeRequest, NavTreeViewModel>
    {
        readonly TestBedState _state;

        public NavTreeSelectNodeRequestHandler(TestBedState state)
        {
            _state = state;
        }

        public Task<NavTreeViewModel> Handle(NavTreeSelectNodeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new NavTreeViewModel
            {
                TreeItems = _state.TreeItems,
                //SelectedNode = _state.TreeItems
            });
        }
    }
}
