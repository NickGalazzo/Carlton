using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Shared.NavTree.Requests;
using Carlton.TestBed.Client.State;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.Shared.NavTree.Handlers
{
    public class SelectComponentRequestHandler : IRequestHandler<SelectComponentRequest, TestBedNavTreeViewModel>
    {
        readonly CarltonTestBedState _state;

        public SelectComponentRequestHandler(CarltonTestBedState state)
        {
            _state = state;
        }

        public Task<TestBedNavTreeViewModel> Handle(SelectComponentRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TestBedNavTreeViewModel
            {
                TreeItems = _state.TreeItems,
                //SelectedNode = _state.TreeItems
            });
        }
    }
}
