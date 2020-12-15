using System.Threading;
using System.Threading.Tasks;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
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
