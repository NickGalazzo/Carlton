using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Carlton.Infrastructure.Commands;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Carlton.Infrastructure.HealthChecks.Database;

namespace Carlton.Infrastructure.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static IServiceProvider ConvertToAutofac(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();
          
            builder.Populate(services);
       
            var dataAccess = Assembly.GetEntryAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                   .AsClosedTypesOf(typeof(ICommandHandler<>));


            var container = builder.Build();


            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        } 

        public static IServiceCollection AddCarltonHealthChecks(this IServiceCollection services, params IHealthCheck[] dependencyHealthChecks)
        {
            var builder = services.AddHealthChecks();

            foreach(var healthCheck in dependencyHealthChecks)
            {
                builder.AddCheck(healthCheck);
            }

            return services;
        }
    }
}
