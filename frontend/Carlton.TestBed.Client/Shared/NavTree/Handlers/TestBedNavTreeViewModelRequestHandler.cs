using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Shared.NavTree.Requests;
using Carlton.TestBed.Client.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.NavTree.Handlers
{
    public class TestBedNavTreeViewModelRequestHandler : GetViewModelRequestHandlerBase<GetTestBedNavTreeViewModelRequest, TestBedNavTreeViewModel>
    {
        public TestBedNavTreeViewModelRequestHandler(CarltonTestBedState state)
            :base(state)
        {
        }

        public override Task<TestBedNavTreeViewModel> Handle(GetTestBedNavTreeViewModelRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TestBedNavTreeViewModel
            {
                TreeItems = State.TreeItems,
                //SelectedNode = _state.TreeItems
            });
        }
    }
}
