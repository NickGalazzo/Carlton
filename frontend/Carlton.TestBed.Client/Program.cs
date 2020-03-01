using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Carlton.Base.Infrastructure.Client.Components.TestBed;

namespace Carlton.TestBed.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSingleton(TestBedBootstrapper.Bootstrap());
            builder.Services.AddSingleton(new TestBedService() { CarltonTreeViewModel = TestBedBootstrapper.Bootstrap() });
            builder.RootComponents.Add<App>("app");


            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
