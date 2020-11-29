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
        public static void AddCarltonState(this IServiceCollection services, Assembly assembly)
        {
            var evtMap = new Dictionary<Type, Type>();

            services.AddSingleton<Func<object, object, IRequest<Unit>>>(provider => (sender, evt) =>
            {
                var map = (IDictionary<Type, Type>)provider.GetService(typeof(IDictionary<Type, Type>));
                var typeToCreate = map[evt.GetType()];
                return (IRequest<Unit>)Activator.CreateInstance(typeToCreate, sender, evt);
            });

            foreach(var type in assembly.GetTypes())
            {
                if(type.IsInterface || type.IsAbstract)
                    continue;

                if(IsRequest(type))
                    RegisterRequest(type, services);

                if(IsComponentEventRequest(type))
                    evtMap.Add(GetInterface(type, typeof(ICarltonComponentEventRequest<>)).GetGenericArguments()[0], type);
            };

            services.AddSingleton<IDictionary<Type, Type>>(evtMap);
        }

        private static void RegisterRequest(Type type, IServiceCollection services)
        {
            var componentEventType = GetInterface(type, typeof(IRequest<>)).GetGenericArguments()[0];
            var componentEventRequestType = typeof(IRequest<>).MakeGenericType(componentEventType);
            services.AddSingleton(componentEventRequestType, type);
        }

        private static Type GetInterface(Type type, Type interfaceType)
        {
            bool predicate(Type _) => _.IsGenericType ? _.GetGenericTypeDefinition() == interfaceType : _ == interfaceType;
            return type.GetInterfaces().FirstOrDefault(predicate);
        }

        private static bool IsRequest(Type t) => GetInterface(t, typeof(IRequest<>)) != null;
        private static bool IsComponentEventRequest(Type t) => GetInterface(t, typeof(ICarltonComponentEventRequest<>)) != null;

    }
}
