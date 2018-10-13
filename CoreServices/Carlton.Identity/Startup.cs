using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Carlton.Identity;
using Carlton.Infrastructure.Containers;

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
            services.AddMvc();

            //configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential() //Development Settings, No need for real cert      
                    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                    .AddInMemoryClients(IdentityServerConfig.GetClients())
                    .AddAspNetIdentity<CarltonUser>();

            //Convert the Container to AutoFac
            return AutofacBuilder.Build(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
