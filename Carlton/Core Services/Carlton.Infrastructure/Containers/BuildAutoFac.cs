using Autofac;
using Autofac.Extensions.DependencyInjection;
using Carlton.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Carlton.Infrastructure.Containers
{
    public class AutofacBuilder
    {
        public static IServiceProvider Build(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
          

            builder.Populate(services);
       

            var dataAccess = Assembly.GetEntryAssembly();

            // builder.Register<ICommand, TestCommand>();

           var xx =  dataAccess.GetTypes().Where(o => o.Name.Contains("Test"));

            builder.RegisterAssemblyTypes(dataAccess)
                   .AsClosedTypesOf(typeof(ICommandHandler<>));


            var container = builder.Build();

        //    var x = container.Resolve<ICommandHandler<>();

            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }
    }
}
