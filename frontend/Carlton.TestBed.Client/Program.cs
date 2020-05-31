using Carlton.Base.Client.Theme;
using Carlton.TestBed.Client.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            var testBedNavService = TestBedBootstrapper.Bootstrap();
  
            builder.Services.AddSingleton(testBedNavService);
            builder.Services.AddSingleton<TestBedViewModelService>();
            builder.Services.AddSingleton<TestBedEventService>();
            builder.Services.AddSingleton<TestBedStatusService>();
            builder.Services.AddSingleton<TestBedService>();

            builder.RootComponents.Add<App>("app");


            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
