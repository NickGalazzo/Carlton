using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.Client.State;
using Carlton.TestBed.Client.Shared.ComponentViewer;
using Carlton.TestBed.Client.Shared.NavTree;
using Carlton.TestBed.Client.Shared.EventConsole;

namespace Carlton.TestBed.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var items = TestBedBootstrapper.Bootstrap();

            var state = new TestBedState(items);

            builder.Services.AddSingleton(state);
            builder.Services.AddSingleton<ICarltonStateStore>(state);
            builder.Services.AddScoped<ICarltonRequestFactory, CarltonRequestFactory>();

            builder.Services.AddMediatR(typeof(App).Assembly);
            builder.Services.AddCarltonState(typeof(App).Assembly, builder =>
            {
                builder.ForComponent<NavTreeViewModel>(_ =>
                {
                    _.AddStateEvent(TestBedState.SELECTED_ITEM)
                     .AddStateEvent(TestBedState.VIEW_MODEL_CHANGED)
                     .AddStateEvent(TestBedState.STATUS_CHANGED);
                })
                .ForComponent<ComponentViewerViewModel>(_ =>
                {
                    _.AddStateEvent(TestBedState.SELECTED_ITEM)
                     .AddStateEvent(TestBedState.VIEW_MODEL_CHANGED);
                })
                .ForComponent<EventConsoleViewModel>(_ =>
                {
                    _.AddStateEvent(TestBedState.COMPONENT_EVENT_ADDED);
                });
            });


            builder.RootComponents.Add<App>("app");
            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
