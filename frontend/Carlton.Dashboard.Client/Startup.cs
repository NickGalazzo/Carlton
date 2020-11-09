using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Carlton.Dashboard.Client
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
           // services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
