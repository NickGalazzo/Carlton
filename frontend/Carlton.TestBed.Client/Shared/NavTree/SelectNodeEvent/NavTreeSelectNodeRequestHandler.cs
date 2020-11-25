using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.Client.State;

namespace Carlton.TestBed.Client.Shared.NavTree
{
    public class NavTreeSelectNodeRequestHandler : TestBedEventRequestHandlerBase<NavTreeSelectNodeRequest>
    {
        public NavTreeSelectNodeRequestHandler(TestBedState state) : base(state)
        {
        }

        public override Task<Unit> Handle(NavTreeSelectNodeRequest request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("WOOOOOOOW");
            return Task.FromResult(Unit.Value);
        }
    }
}
