using System;
using MediatR;
using Carlton.Base.Client.State;


namespace Carlton.TestBed.Client
{
    public class CarltonRequestFactory : ICarltonRequestFactory
    {
        private readonly IServiceProvider _provider;

        public CarltonRequestFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IRequest<Unit> GetComponentEventRequest<TComponentEvent>(ICarltonComponentEvent evt)
                  where TComponentEvent : ICarltonComponentEvent
        {
            Console.WriteLine("Made it to request Mapper");
            var func = _provider.GetService(typeof(ICarltonComponentEventRequest<TComponentEvent>));
            Console.WriteLine("TComponentEvent: " + typeof(TComponentEvent).FullName);
            Console.WriteLine(typeof(ICarltonComponentEventRequest<TComponentEvent>).FullName + " : " + func == null);
            var castedFunc = (Func<ICarltonComponentEvent, IRequest<Unit>>)func;
            Console.WriteLine("Casted Func");
            var request = castedFunc(evt);
            return request;
        }

        public IRequest<TViewModel> GetViewModelRequest<TViewModel>()
        {
            return (IRequest<TViewModel>)_provider.GetService(typeof(IRequest<TViewModel>));
        }
    }
}


