using Carlton.Infrastructure.Caching;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Carlton.Domain.Interceptors
{
    public class CachingInterceptor : IInterceptor
    {
        private readonly ILogger<CachingInterceptor> _logger;
        private readonly IMemoryCache _cache;
        private readonly ICacheKeyGenerator _cacheKeyGenerator;
        private readonly ICacheDurationGenerator _cacheDurationGenerator;

        public CachingInterceptor(ILogger<CachingInterceptor> logger, IMemoryCache cache,
            ICacheKeyGenerator cacheKeyGenerator, ICacheDurationGenerator cacheDurationGenerator)
        {
            _logger = logger;
            _cache = cache;
            _cacheKeyGenerator = cacheKeyGenerator;
            _cacheDurationGenerator = cacheDurationGenerator;
        }

        public void Intercept(IInvocation invocation)
        {
            var key = _cacheKeyGenerator.GenerateCacheKey(JsonConvert.SerializeObject(invocation.Arguments));
            
            var returnValue = _cache.Get(key);

            if (returnValue != null)
            {
                invocation.ReturnValue = returnValue;
                return;
            }

            invocation.Proceed();

            if (invocation.ReturnValue != null)
            {
                var cacheExpiresIn = _cacheDurationGenerator.GetCacheDuration(invocation);
                _cache.Set(key, invocation.ReturnValue, cacheExpiresIn);
            }
        }
    }
}
