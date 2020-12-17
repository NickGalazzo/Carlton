using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Carlton.Base.Client.State
{
    public static class ContainerExtensions
    {
        public static void AddCarltonState(this IServiceCollection services, Action<CarltonStateEventMapBuiler> builder, params Assembly[] assemblies)
        {
            //Build StateEvents Map
            var semb = new CarltonStateEventMapBuiler();
            builder(semb);
            var componentEvtMap = semb.Build();

            //Register StateEvents Map
            services.AddSingleton(componentEvtMap);

            //Register Requests
            services.Scan(_ =>
                {
                    _.FromAssemblies(assemblies)
                        .AddClasses(classes => classes.AssignableTo(typeof(ICarltonComponent<>)))
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime();
                    _.FromAssemblies(assemblies)
                        .AddClasses(classes => classes.AssignableTo(typeof(IRequest<Unit>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime();
                    _.FromAssemblies(assemblies)
                        .AddClasses(classes => classes.AssignableTo(typeof(IRequest<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime();                    
                });

            //Register factory
            services.AddSingleton(CreateComponentRequestLookup());
            services.AddSingleton(CreateViewModelLookup());
            services.AddSingleton<ICarltonStateFactory, CarltonStateFactory>();
        }

        private static ViewModelLookup CreateViewModelLookup()
        {
            var result = new ViewModelLookup();

            //Loop through Assemblies of types impementing ICarltonComponents<>
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                            .SelectMany(_ => _.GetTypes())
                                            .Where(_ => _.GetInterfaces()
                                                         .Any(expression));

            foreach(Type type in types)
            {
                //Get the ComponentEvent Type
                var viewModelType = type.GetInterfaces()
                                              .First(expression)
                                              .GetGenericArguments()[0];

                //Map ViewModel => Component
                result[viewModelType] = type;
            }

            return result;

            static bool expression(Type _) => _.IsGenericType && _.GetGenericTypeDefinition().Equals(typeof(ICarltonComponent<>));
        }

        private static ComponentEventRequestLookup CreateComponentRequestLookup()
        {
            var result = new ComponentEventRequestLookup();
            
            //Loop through Assemblies of types impementing ICarltonComponentEventRequest<>
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                            .SelectMany(_ => _.GetTypes())
                                            .Where(_ => _.GetInterfaces()
                                                         .Any(expression));
            foreach(Type type in types)
            {
                System.Console.WriteLine($"Requet Type: {type}");

                //Get the ComponentEvent Type
                var componentEventType = type.GetInterfaces()
                                              .First(expression)
                                              .GetGenericArguments()[0];

                //Map ComponentEvent => ComponentEventRequest
                result[componentEventType] = type;
            }

            return result;

            static bool expression(Type _) => _.IsGenericType && _.GetGenericTypeDefinition().Equals(typeof(ICarltonComponentEventRequest<>));
        }
    }
}

