
using Carlton.Base.Infrastructure.Client.Data;
using Carlton.Dashboard.ViewModels.HomeForDinner;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Carlton.Dashboard.Client
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataService<HomeForDinnerViewModel>, TestDataService>();
           // services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}