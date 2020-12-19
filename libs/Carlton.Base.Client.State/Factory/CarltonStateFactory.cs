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
        private readonly ComponentEventRequestLookup _evtLookup;
        private readonly ViewModelLookup _vmLookup;

        public CarltonStateFactory(IServiceProvider provider,
            ComponentEventRequestLookup evtLookup,
            ViewModelLookup vmLookup)
        {
            _provider = provider;
            _evtLookup = evtLookup;
            _vmLookup = vmLookup;
        }

        public Type GetComponentType<TViewModel>()
        {
            return _vmLookup[typeof(TViewModel)];
        }

        public IEnumerable<string> GetComponentStateEvents<TViewModel>()
        {
            Console.WriteLine("Count is =" +
                _provider.GetServices<CarltonComponentStateEvents>().Count());
            var result = _provider.GetServices<CarltonComponentStateEvents>()
                             .FirstOrDefault(_ => _.ViewModelType == typeof(TViewModel));
            return result ?? Enumerable.Empty<string>();
        }

        public IRequest<TViewModel> CreateViewModelRequest<TViewModel>()
        {
            return _provider.GetRequiredService<IRequest<TViewModel>>();
        }

        public IRequest<Unit> CreateComponentEventRequest(object sender, object componentEvent)
        {
            var requestType = _evtLookup[componentEvent.GetType()];
            return (IRequest<Unit>)Activator.CreateInstance(requestType, sender, componentEvent);
        }
    }
}
