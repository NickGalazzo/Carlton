using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc
{
    public class SprocInfoBuilder<T>
    {
        private string _sprocName;
        private readonly Dictionary<string, object> _parameters
            = new Dictionary<string, object>();
        private SprocResultMapping<T> _mapping;
        private readonly Dictionary<string, Expression<Func<T, object>>> _paramToPropMap =
            new Dictionary<string, Expression<Func<T, object>>>();

        public SprocInfoBuilder<T> Sprocname(string sprocName)
        {
            _sprocName = sprocName;
            return this;
        }

        public SprocInfoBuilder<T> IdParamName(string name)
        {
            _parameters.Add(name, SprocConstants.ID_PLACE_HOLDER);
            return this;
        }

        public SprocInfoBuilder<T> AddParameter(string paramName, object value)
        {
            _parameters.Add(paramName, value);
            return this;
        }

        public SprocInfoBuilder<T> AddParameterFromProperty(string paramName, Expression<Func<T, object>> propExpression)
        {
            _paramToPropMap.Add(paramName, propExpression);
            return this;
        }

        public SprocInfoBuilder<T> AddMappings(Type[] types, Func<object, T> mapFunc, string[] splitColumns)
        {
            _mapping = new SprocResultMapping<T>(types, mapFunc, splitColumns);
            return this;
        }

        public SprocInfo<T> Build()
        {
            var result = new SprocInfo<T>(_sprocName, _parameters, _paramToPropMap);
            return result;
        }
    }
}
