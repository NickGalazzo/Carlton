using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc
{
    public class RepositorySprocBuilder<T>
    {
        private string _sprocName;
        private readonly Dictionary<string, Expression<Func<T, object>>> _propertyParams
            = new Dictionary<string, Expression<Func<T, object>>>();
        private SprocResultMapping<T> _mapping;

        public RepositorySprocBuilder<T> Sprocname(string sprocName)
        {
            _sprocName = sprocName;
            return this;
        }

        public RepositorySprocBuilder<T> AddPropertyParameter(string paramName, Expression<Func<T, object>> property)
        {
            _propertyParams.Add(paramName, property);
            return this;
        }

        public RepositorySprocBuilder<T> AddMappings(Type[] types, Func<object, T> mapFunc, string[] splitColumns)
        {
            _mapping = new SprocResultMapping<T>(types, mapFunc, splitColumns);
            return this;
        }

        public SprocInfo<T> Build()
        {
            return new SprocInfo<T>(_sprocName, _propertyParams, _mapping);
        }
    }
}
