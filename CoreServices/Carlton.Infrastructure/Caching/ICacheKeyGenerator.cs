using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Infrastructure.Caching
{
    public interface ICacheKeyGenerator
    {
        string GenerateCacheKey(object obj);
    }
}
