using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeViewModelRequestHandler : TestBedRequestHandlerViewModelBase<NavTreeViewModelRequest, NavTreeViewModel>
    {
        public NavTreeViewModelRequestHandler(TestBedState state)
            :base(state)
        {
        }

        public override Task<NavTreeViewModel> Handle(NavTreeViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new NavTreeViewModel(State.TreeItems, State.SelectedItem, null));
        }
    }
}
