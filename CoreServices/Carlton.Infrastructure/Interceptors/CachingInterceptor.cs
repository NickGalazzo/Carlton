using Carlton.Infrastructure.Caching;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Carlton.Infrastructure.Interceptors
{
    public class CachingInterceptor : BaseInterceptor
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

        public override void InterceptBehavior(IInvocation invocation)
        {
            var key = _cacheKeyGenerator.GenerateCacheKey(JsonConvert.SerializeObject(invocation.Arguments));

            var returnValue = _cache.Get(key);

            if (returnValue != null)
            {
                _logger.LogInformation($"{invocation.Method.Name} is retrieving value from Memory Cache");
                invocation.ReturnValue = returnValue;
                return;
            }
            else
            {
                _logger.LogInformation($"{invocation.Method.Name} is unable to retrieve value from Memory Cache");
            }

            invocation.Proceed();

            if (invocation.ReturnValue != null)
            {
                _logger.LogInformation($"{nameof(invocation.ReturnValue)} is being placed in memory cache");
                var cacheExpiresIn = _cacheDurationGenerator.GetCacheDuration(invocation);
                _cache.Set(key, invocation.ReturnValue, cacheExpiresIn);
            }
        }
    }
}
