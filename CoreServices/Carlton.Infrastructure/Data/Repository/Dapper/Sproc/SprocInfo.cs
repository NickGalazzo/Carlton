using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public class SprocInfo<T>
    {
        public string SprocName { get; }
        public Dictionary<string, Expression<Func<T, object>>> ParamPropertyMappings { get; }
        public SprocResultMapping<T> SprocMapping { get; }

        public SprocInfo(string sprocName, Dictionary<string, Expression<Func<T, object>>> paramPropertyMappings) : this(sprocName, paramPropertyMappings, null)
        {
        } 

        public SprocInfo(string sprocName, Dictionary<string, Expression<Func<T, object>>> paramPropertyMappings, SprocResultMapping<T> mapping)
        {
            SprocName = sprocName;
            ParamPropertyMappings = paramPropertyMappings;
            SprocMapping = mapping;
        }
    }
}
       

