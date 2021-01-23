using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Carlton.TestBed.State;
using Microsoft.JSInterop;

namespace Carlton.TestBed.Components
{
    public record SourceViewerViewModel(string ComponentSource);

    public class  SourceViewerViewModelRequest : IRequest<SourceViewerViewModel>
    {
    }
    
    public class SourceViewerViewModelRequestHandler : TestBedRequestHandlerViewModelBase<SourceViewerViewModelRequest, SourceViewerViewModel>
    {
        private const string PROJECT_NAME = "Carlton.TestBed";
        private readonly IJSRuntime _jsRuntime; 

        public SourceViewerViewModelRequestHandler(IJSRuntime jsRuntime, TestBedState state) : base(state)
        {
            _jsRuntime = jsRuntime;
        }

        public async override Task<SourceViewerViewModel> Handle(SourceViewerViewModelRequest request, CancellationToken cancellationToken)
        {
            var module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", $"./_content/{PROJECT_NAME}/js/sourceViewer.razor.js");
            var markup = await module.InvokeAsync<string>("getOutputSource");

            return new SourceViewerViewModel(markup);
        }
    }
}
