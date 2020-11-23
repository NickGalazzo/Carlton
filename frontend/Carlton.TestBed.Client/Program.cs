using AutoMapper;
using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Services;
using Carlton.TestBed.Client.State;
using MediatR;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;
using Carlton.Base.Client.State;

namespace Carlton.TestBed.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var items = TestBedBootstrapper.Bootstrap();

            var state = new CarltonTestBedState(items);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddSingleton(state);
            builder.Services.AddSingleton<ICarltonStateStore>(state);
            builder.Services.AddScoped<ICarltonRequestFactory, TestBedRequestMapper>();


            //Simplfy and move eto extension method
            typeof(Program).Assembly.GetTypes()
                                    .Where(o => o.BaseType.IsGenericType)
                                    .Where(o => o.BaseType.GetGenericTypeDefinition() == typeof(GetViewModelRequestHandlerBase<,>))
                                    .ToList()
                                    .ForEach(o =>
                                    {
                                        System.Console.WriteLine(o);
                                        var typeArgs = o.BaseType.GetGenericArguments();
                                        var requestType = typeArgs[0];
                                        var vmType = typeArgs[1];
                                        var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, vmType);
                                        builder.Services.AddScoped(requestHandlerType, o);
                                    });


            System.Console.WriteLine("test");
            typeof(Program).Assembly.GetTypes()
                                    .Where(o => o.GetInterfaces()
                                        .Any(o => o.IsGenericType && o.GetGenericTypeDefinition() == typeof(ICarltonViewModelRequest<>)))
                                    .ToList()
                                    .ForEach(o =>
                                    {
                                        System.Console.WriteLine(o);
                                        var vmType = o.GetInterfaces().First(o => o.IsGenericType && o.GetGenericTypeDefinition() == typeof(ICarltonViewModelRequest<>))
                                                                      .GetGenericArguments()[0];
                                        builder.Services.AddScoped(typeof(IRequest<>).MakeGenericType(vmType), o);
                                        System.Console.WriteLine(o);
                                    });


            //  builder.Services.AddScoped<IRequest<TestBedNavTreeViewModel>, GetTestBedNavTreeViewModelRequest>();
            //  builder.Services.AddScoped<IRequestHandler<GetTestBedNavTreeViewModelRequest, TestBedNavTreeViewModel>, GetTestBedNavTreeViewModelRequestHandler>();

            ///builder.Services.AddScoped<IRequest<ComponentViewerViewModel>, GetTestBedComponentViewerViewModelRequest>();
            // builder.Services.AddScoped<IRequestHandler<GetTestBedComponentViewerViewModelRequest, ComponentViewerViewModel>, GetTestBedComponentViewModelRequestHandler>();


            builder.Services.AddMediatR(typeof(App).Assembly);

            // builder.Services.AddMediatR(typeof(TestBedNavTreeViewModel));

            builder.Services.AddSingleton<TestBedViewModelService>();
            builder.Services.AddSingleton<TestBedEventService>();
            builder.Services.AddSingleton<TestBedStatusService>();
            builder.Services.AddSingleton<TestBedService>();

            builder.RootComponents.Add<App>("app");


            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}
