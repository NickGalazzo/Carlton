using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Shared.NavTree.Requests;
using Carlton.TestBed.Client.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.NavTree.Handlers
{
    public class NavTreeSelectNodeRequestHandler : IRequestHandler<NavTreeSelectNodeRequest, NavTreeViewModel>
    {
        readonly CarltonTestBedState _state;

        public NavTreeSelectNodeRequestHandler(CarltonTestBedState state)
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
