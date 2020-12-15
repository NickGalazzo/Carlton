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
        public static void AddCarltonState(this IServiceCollection services, Action<StateEventMapperBuiler> builder, params Assembly[] assemblies)
        {
            var evtMap = new Dictionary<Type, Type>();

            //Register a utility function that creates the correct IRequest types for ViewModel requests
            services.AddSingleton<Func<object, object, IRequest<Unit>>>(provider => (sender, evt) =>
            {
                var map = (IDictionary<Type, Type>)provider.GetService(typeof(IDictionary<Type, Type>));
                var typeToCreate = map[evt.GetType()];
                return (IRequest<Unit>)Activator.CreateInstance(typeToCreate, sender, evt);
            });

            //Search assemblies and create a dictionary for 
            foreach(var type in assemblies.SelectMany(_ => _.GetTypes()))
            {
                if(type.IsInterface || type.IsAbstract)
                    continue;

                //Register ComponentEvent Requests
                if(IsRequest(type))
                    RegisterRequest(type, services);

                //Create a dictionary of event types to requests
                if(IsComponentEventRequest(type))
                    evtMap.Add(GetInterface(type, typeof(ICarltonComponentEventRequest<>)).GetGenericArguments()[0], type);
            };

            //Register the Dictionary
            services.AddSingleton<IDictionary<Type, Type>>(evtMap);

            //Register the StateEventLookup
            var semb = new StateEventMapperBuiler();
            builder(semb);
            services.AddSingleton(semb.Build());

            //Register the StateEventLookup Function
            services.AddSingleton<Func<Type, IEnumerable<string>>>(provider => (Type t) =>
            {
                var map = (IDictionary<Type, IEnumerable<string>>)provider.GetService(typeof(IDictionary<Type, IEnumerable<string>>));
                return map[t];
            });
        }

        //Register IRequests for component events
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

    public class StateEventMapperBuiler
    {
        private readonly IDictionary<Type, IEnumerable<string>> _stateMappings = new Dictionary<Type, IEnumerable<string>>();

        public StateEventMapperBuiler ForComponent<TViewModel>(Action<EventListBuider> builder)
        {
            var eb = new EventListBuider();
            builder(eb);
            _stateMappings.Add(new KeyValuePair<Type, IEnumerable<string>>(typeof(TViewModel), eb.Build()));
            return this;
        }

        public IDictionary<Type, IEnumerable<string>> Build()
        {
            return _stateMappings;
        }

        public class EventListBuider
        {
            private readonly IList<string> _stateEvents = new List<string>();
                        
            public void AddStateEvent(string stateEvent)
            {
                _stateEvents.Add(stateEvent);
            }

            public IEnumerable<string> Build()
            {
                return _stateEvents;
            }
        }
    }
}
