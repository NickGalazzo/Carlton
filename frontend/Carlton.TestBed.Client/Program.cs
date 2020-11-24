using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.Client.State;
using System;

namespace Carlton.TestBed.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var items = TestBedBootstrapper.Bootstrap();

            var state = new TestBedState(items);

            builder.Services.AddAutoMapper(typeof(Program));

 
            builder.Services.AddSingleton(state);
            builder.Services.AddSingleton<ICarltonStateStore>(state);
            builder.Services.AddScoped<ICarltonRequestFactory, CarltonRequestFactory>();

            builder.Services.AddCarltonState();
          

            builder.Services.AddMediatR(typeof(App).Assembly);

            // builder.Services.AddMediatR(typeof(TestBedNavTreeViewModel));

            builder.RootComponents.Add<App>("app");


            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
