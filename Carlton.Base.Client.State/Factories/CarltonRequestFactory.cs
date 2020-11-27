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

        public IRequest<Unit> GetComponentEventRequest(object sender, object evt)
        {
            Console.WriteLine("Made it here");
            var func = (Func<object, object, IRequest<Unit>>)_provider.GetService(typeof(Func<object, object, IRequest<Unit>>));
            Console.WriteLine("Got Func" + ": is null" + func == null);
            var request = func(sender, evt);
            Console.WriteLine("Got request");
            return request;
        }

        public IRequest<TViewModel> GetViewModelRequest<TViewModel>()
        {
            return (IRequest<TViewModel>)_provider.GetService(typeof(IRequest<TViewModel>));
        }
    }
}


