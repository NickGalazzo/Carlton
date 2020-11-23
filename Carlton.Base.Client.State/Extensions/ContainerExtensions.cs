using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Carlton.Base.Client.State
{
    public static class ContainerExtensions
    {
        private static readonly Func<Type, Type> getRequestInterface = o => o.GetInterfaces().FirstOrDefault(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IRequest<>));
        private static readonly Func<Type, Type> getHandlerInterface = o => o.GetInterfaces().FirstOrDefault(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IRequestHandler<>));

        private static readonly Func<Type, bool> isRequest = o => getRequestInterface(o) != null;
        private static readonly Func<Type, bool> isHandler = o => getHandlerInterface(o) != null;

        public static void AddCarltonState(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            foreach(var type in assembly.GetTypes())
            {
                if(type.IsInterface)
                    continue;
                else if(isRequest(type))
                    RegisterRequest(type, services);
                else if(isHandler(type))
                    RegisterHandler(type, services);
                else
                    continue;
            }
        }

        private static void RegisterRequest(Type type, IServiceCollection services)
        {
            System.Console.WriteLine("Request:" + type + " " );
            type.GetInterfaces().ToList().ForEach(o => Console.WriteLine(o.FullName));
            var vmType = getRequestInterface(type).GetGenericArguments()[0];
            services.AddScoped(typeof(IRequest<>).MakeGenericType(vmType), type);
        }

        private static void RegisterHandler(Type type, IServiceCollection services)
        {
            System.Console.WriteLine("Handler:" + type);
            var typeArgs = getHandlerInterface(type).GetGenericArguments();
            var requestType = typeArgs[0];
            var vmType = typeArgs[1];
            var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, vmType);
            services.AddScoped(requestHandlerType, type);
        }
    }
}
