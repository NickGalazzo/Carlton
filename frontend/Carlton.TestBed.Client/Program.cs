using Carlton.Base.Infrastructure.Client.Components.Tree;
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

            builder.Services.AddSingleton(TestBedBootstrapper.Bootstrap());
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
