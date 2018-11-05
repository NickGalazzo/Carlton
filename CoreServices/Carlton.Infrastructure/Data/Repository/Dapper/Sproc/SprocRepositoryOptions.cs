using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public class SprocRepositoryOptions<T>
    {
        public Dictionary<string, SprocInfo<T>> Sprocs { get; }
        public Delegate Map { get; }
     

        public SprocRepositoryOptions(IEnumerable<SprocInfo<T>> sprocs, Delegate map)
        {
            Sprocs = sprocs.ToDictionary(o => o.SprocName, o => o);
            Map = map;
        }
    }
}
