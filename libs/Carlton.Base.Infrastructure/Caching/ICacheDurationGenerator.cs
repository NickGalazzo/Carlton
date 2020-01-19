using System;

namespace Carlton.Infrastructure.Caching
{
    public interface ICacheDurationGenerator
    {
        TimeSpan GetCacheDuration(object obj);
    }
}
