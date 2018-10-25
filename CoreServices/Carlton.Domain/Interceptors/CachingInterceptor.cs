using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Carlton.Domain.Interceptors
{
    public class CachingInterceptor : IInterceptor
    {
        private readonly ILogger<CachingInterceptor> _logger;
        private readonly IMemoryCache _cache;

        public CachingInterceptor(ILogger<CachingInterceptor> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public void Intercept(IInvocation invocation)
        {
            var key = GenerateKey(JsonConvert.SerializeObject(invocation.Arguments));
            
            var returnValue = _cache.Get(key);

            if (returnValue != null)
            {
                invocation.ReturnValue = returnValue;
                return;
            }

            invocation.Proceed();

            if (invocation.ReturnValue != null)
            {
                var cacheExpiresIn = GetCacheObjectDuration(invocation);

                _cache.Set(key, invocation.ReturnValue, new TimeSpan(0, 0, cacheExpiresIn));
            }
        }

        private object GetCacheObjectDuration(IInvocation invocation)
        {
            throw new NotImplementedException();
        }

        private object GenerateKey(object p)
        {
            throw new NotImplementedException();
        }
    }
}
