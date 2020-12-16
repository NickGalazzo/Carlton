using System;
using System.Linq;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Carlton.Base.Client.State
{
    public class CarltonStateFactory : ICarltonStateFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ComponentEventRequestLookup _lookup;

        public CarltonStateFactory(IServiceProvider provider, ComponentEventRequestLookup lookup)
        {
            _provider = provider;
            _lookup = lookup;
        }

        public Type GetComponentType<TViewModel>()
        {
            return null;
        }

        public IEnumerable<string> GetComponentStateEvents<TViewModel>()
        {
            Console.WriteLine("Count is =" +
                _provider.GetServices<CarltonComponentStateEvents>().Count());
            return ((IEnumerable<CarltonComponentStateEvents>)_provider.GetServices(typeof(CarltonComponentStateEvents)))
                .FirstOrDefault(_ => _.ViewModelType == typeof(TViewModel));
        }

        public IRequest<TViewModel> CreateViewModelRequest<TViewModel>()
        {
            return _provider.GetRequiredService<IRequest<TViewModel>>();
        }

        public IRequest<Unit> CreateComponentEventRequest(object sender, object componentEvent)
        {
            var requestType = _lookup[componentEvent.GetType()];
            return (IRequest<Unit>)Activator.CreateInstance(requestType, sender, componentEvent);
        }
    }
}
