using Carlton.TestBed.Client.State;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeViewModelRequestHandler : GetViewModelRequestHandlerBase<NavTreeViewModelRequest, NavTreeViewModel>
    {
        public NavTreeViewModelRequestHandler(CarltonTestBedState state)
            :base(state)
        {
        }

        public override Task<NavTreeViewModel> Handle(NavTreeViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new NavTreeViewModel
            {
                TreeItems = State.TreeItems,
                //SelectedNode = _state.TreeItems
            });
        }
    }
}
