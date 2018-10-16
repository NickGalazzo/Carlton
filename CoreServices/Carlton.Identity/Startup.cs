using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Carlton.Identity;
using Carlton.Infrastructure.Extensions;
using Carlton.Infrastructure.HealthChecks.Database;

namespace Calrton.Identity
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Add EF with Postgres
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<CarltonIdentityContext>(options => options.UseNpgsql(_configuration.GetConnectionString("CaltonIdentityDatabase")));

            //Add Identity Core          
            services.AddIdentity<CarltonUser, IdentityRole>()
                    .AddEntityFrameworkStores<CarltonIdentityContext>()
                    .AddDefaultTokenProviders();

            //Add MVC
            services.AddMvc(options =>
            {
                options.Filters.Add(new CarltonStandardResultFilter());
            });

            //configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential() //Development Settings, No need for real cert      
                    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                    .AddInMemoryClients(IdentityServerConfig.GetClients())
                    .AddAspNetIdentity<CarltonUser>();


            var x = _configuration.GetConnectionString("CaltonIdentityDatabase");
            services.AddCarltonHealthChecks(new PostgresConnectionHealthCheck("MyDB", x));
            services.AddElm();


            //Convert the Container to AutoFac
            return services.ConvertToAutofac();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCarltonApiExceptionResponseMessage();
            }

            app.UseCarltonExceptionHandling();

            app.UseElmCapture();
            app.UseElmPage();

            app.UseIdentityServer();


            app.UseMvc();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
