using System;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Carlton.Base.Client.State
{
    public static class ContainerExtensions
    {
        public static void AddCarltonState(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            foreach(var type in assembly.GetTypes())
            {
                if(type.IsInterface || type.IsAbstract)
                    continue;
                else if(IsComponentEventRequest(type))
                    RegisterComponentEventRequest(type, services);
                else if(IsViewModelRequest(type))
                    RegisterViewModelRequest(type, services);
                else if(IsHandler(type))
                    RegisterHandler(type, services);
                else
                    continue;
            };
        }

        private static IRequest<Unit> CreateComponentEventRequest(ICarltonComponentEvent evt, Type type)
        {
            return (IRequest<Unit>)Activator.CreateInstance(type, evt);
        }

        private static void RegisterComponentEventRequest(Type type, IServiceCollection services)
        {
            Console.WriteLine("ComponentEvent Request:" + type + " ");
            var componentEventType = GetComponentEventRequestInterface(type).GetGenericArguments()[0];
            var componentEventRequestType = typeof(ICarltonComponentEventRequest<>).MakeGenericType(componentEventType);
            Console.WriteLine(componentEventRequestType.FullName);
            services.AddSingleton(componentEventRequestType,
              new Func<ICarltonComponentEvent, IRequest<Unit>>((evt) => CreateComponentEventRequest(evt, type)));
            Console.WriteLine("did this work");
        }

        private static void RegisterViewModelRequest(Type type, IServiceCollection services)
        {
          //  Console.WriteLine("ViewModel Request:" + type + " ");
            var vmType = GetViewModelRequestInterface(type).GetGenericArguments()[0];
            services.AddScoped(typeof(IRequest<>).MakeGenericType(vmType), type);
        }

        private static void RegisterHandler(Type type, IServiceCollection services)
        {
            //Console.WriteLine("Handler:" + type);
            var typeArgs = GetHandlerInterface(type).GetGenericArguments();
            var requestType = typeArgs[0];
            var vmType = typeArgs[1];
            var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, vmType);
            services.AddScoped(requestHandlerType, type);
        }

        private static Type GetInterface(Type type, Type interfaceType)
        {
            return type.GetInterfaces().FirstOrDefault(_ => _.IsGenericType && _.GetGenericTypeDefinition() == interfaceType.GetGenericTypeDefinition());
        }

        private static Type GetComponentEventRequestInterface(Type t) => GetInterface(t, typeof(ICarltonComponentEventRequest<>));
        private static Type GetViewModelRequestInterface(Type t) => GetInterface(t, typeof(ICarltonViewModelRequest<>));
        private static Type GetHandlerInterface(Type t) => GetInterface(t, typeof(IRequestHandler<>));

        private static bool IsComponentEventRequest(Type t) => GetComponentEventRequestInterface(t) != null;
        private static bool IsViewModelRequest(Type t) => GetInterface(t, typeof(ICarltonViewModelRequest<>)) != null;
        private static bool IsHandler(Type t) => GetHandlerInterface(t) != null;
    }
}
