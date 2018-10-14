using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Carlton.Infrastructure.Commands;

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
    }
}
