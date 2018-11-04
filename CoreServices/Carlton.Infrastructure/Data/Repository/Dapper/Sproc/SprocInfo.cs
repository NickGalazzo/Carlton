using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public class SprocInfo<T>
    {
        public string SprocName { get; }
        public Dictionary<string, object> Parameters { get; }
        public SprocResultMapping<T> SprocMapping { get; }

        private readonly Dictionary<string, Expression<Func<T, object>>> _paramToPropMap;

        internal SprocInfo(string sprocName, Dictionary<string, object> parameters, Dictionary<string, Expression<Func<T, object>>> paramToPropMap)
            : this(sprocName, parameters, paramToPropMap, null)
        {
        } 

        internal SprocInfo(string sprocName, Dictionary<string, object> parameters,
            Dictionary<string, Expression<Func<T, object>>> paramToPropMap,SprocResultMapping<T> mapping)
        {
            SprocName = sprocName;
            Parameters = parameters;
            SprocMapping = mapping;
            _paramToPropMap = new Dictionary<string, Expression<Func<T, object>>>();
        }

        internal bool AnyParameterProperties()
        {
            return _paramToPropMap.Count != 0;
        }

        internal void ConvertEntityPropertiesToParams(T entity)
        {
            foreach(var prop in _paramToPropMap)
            {
                Parameters.Add(prop.Key, GetPropertyValue(prop.Value, entity));
            }
        }

        private object GetPropertyValue(Expression<Func<T, object>> prop, T entity)
        {
            var propertyInfo = ((MemberExpression)prop.Body).Member as PropertyInfo;
            var value = propertyInfo.GetValue(entity);
            return value;
        }
    }
}
       

