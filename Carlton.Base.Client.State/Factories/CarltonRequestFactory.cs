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

        public IRequest<Unit> GetComponentEventRequest(object evt)
        {
            var func = (Func<object, IRequest<Unit>>)_provider.GetService(typeof(Func<object, IRequest<Unit>>));
            var request = func(evt);
            return request;
        }

        public IRequest<TViewModel> GetViewModelRequest<TViewModel>()
        {
            return (IRequest<TViewModel>)_provider.GetService(typeof(IRequest<TViewModel>));
        }
    }
}


