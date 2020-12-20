using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record SourceViewerViewModel(string ComponentSource);

    public class SourceViewerViewModelRequest : IRequest<SourceViewerViewModel>
    {
    }

    public class SourceViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<SourceViewerViewModelRequest, SourceViewerViewModel>
    {
        private readonly HttpClient _client;

        public SourceViewerViewModelRequestHandler(HttpClient client, TestBedState state) : base(state)
        {
            _client = client;
        }

        public async override Task<SourceViewerViewModel> Handle(SourceViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Made it to SourceViewerViewModelRequestHandler");

            var projectName = "Carlton.Dashboard.Components";
            var path = $"_content/{projectName}/Test/ToDo.Test.txt";
            await Task.Delay(10).ConfigureAwait(true); //_client.GetStringAsync(path, cancellationToken);

            return new SourceViewerViewModel(@"@using Carlton.Dashboard.Components
                    @using Carlton.Dashboard.ViewModels 
                    <ToDoListItem ViewModel='ViewModel' OnComponentEvent='Callback' />");
        }
    }
}
