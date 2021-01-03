using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Components
{
    public record SourceViewerViewModel(string ComponentSource);

    public class  SourceViewerViewModelRequest : IRequest<SourceViewerViewModel>
    {
    }
    
    public class SourceViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<SourceViewerViewModelRequest, SourceViewerViewModel>
    {
        private readonly HttpClient _client;
        private readonly SourceConfig _config;

        public SourceViewerViewModelRequestHandler(HttpClient client, SourceConfig config, TestBedState state) : base(state)
        {
            _client = client;
            _config = config;
        }

        public async override Task<SourceViewerViewModel> Handle(SourceViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            var path = $"_content/{_config.SourceBasePath}/{State.SelectedItem.Type.Name}.txt";
            var source = await _client.GetStringAsync(path, cancellationToken);
            return new SourceViewerViewModel(source);
        }
    }
}
