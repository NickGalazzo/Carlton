using Carlton.Client.Base.Data;
using Carlton.Dashboard.Components.HomeForDinner;
using Carlton.Dashboard.ViewModels.HomeForDinner;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Carlton.Dashboard.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataService<HomeForDinnerViewModel>, TestDataService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
