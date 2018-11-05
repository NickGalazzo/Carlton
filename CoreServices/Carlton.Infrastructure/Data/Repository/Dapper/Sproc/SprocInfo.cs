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
        public SprocRepositoryOptions<T> SprocMapping { get; }

        internal  Dictionary<string, Expression<Func<T, object>>> ParamToPropMap { get; }

        internal SprocInfo(string sprocName)
        {
            SprocName = sprocName;
        }

        internal bool AnyParameterProperties()
        {
            return ParamToPropMap.Count != 0;
        }

        internal void ConvertEntityPropertiesToParams(T entity)
        {
            foreach (var prop in ParamToPropMap)
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


