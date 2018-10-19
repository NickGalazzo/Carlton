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
using Carlton.Infrastructure.MvcFilters;
using Swashbuckle.AspNetCore.Swagger;
using Carlton.Infrastructure.Configuration;
using Carlton.Infrastructure.Correlation;

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
            //Add Logging
            services.AddCarltonLogging(_configuration);

            //Add TraceIdentifier
            services.AddScoped<TraceIdentifier>();

            //Add Base Carlton Configuration
            services.Configure<CarltonConfiguration>(_configuration.GetSection("CarltonConfiguration"));

            //Add Services for Health Checks
            services.AddCarltonHealthChecks(new PostgresConnectionHealthCheck("MyDB", _configuration.GetConnectionString("CaltonIdentityDatabase")));

            //Add Services for ELM
            services.AddElm();

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

            //Add WebAPI Versioning
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            //configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential() //Development Settings, No need for real cert      
                    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                    .AddInMemoryClients(IdentityServerConfig.GetClients())
                    .AddAspNetIdentity<CarltonUser>();

            //Convert the Container to AutoFac
            return services.ConvertToAutofac();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AddExceptionMiddleware(app, env);
            app.UseElmCapture();
            app.UseElmPage();
            app.UseCarltonHealthChecking();
            app.UseCalrtonMetadata("/metadata");
            app.UseCarltonCorelationId();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseIdentityServer();
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static void AddSpecialEndpointMiddleware(IApplicationBuilder app)
        {
           
        }

        private static void AddExceptionMiddleware(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCarltonApiExceptionResponseMessage();
            }

            app.UseCarltonExceptionHandling();
        }
    }
}
