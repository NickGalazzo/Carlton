using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc
{
    public class SprocRepositoryOptionsBuilder<T>
    {
        private readonly IList<SprocInfo<T>> _sprocs = new List<SprocInfo<T>>();
        private Delegate _map;
        private string _splitColumns;
       
        public SprocRepositoryOptionsBuilder<T> WithSproc(string sprocName, Action<SprocInfoBuilder<T>> action)
        {
            var sprocBuilder = new SprocInfoBuilder<T>(sprocName);
            action(sprocBuilder);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithMap<TFirst, TSecond, TReturn>(Func<TFirst, TSecond, TReturn> map, params string[] splitColumns)
        {
            _map = map;
            _splitColumns = string.Join(",", splitColumns);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithMap<TFirst, TSecond, TThird, TReturn>(Func<TFirst, TSecond, TThird, TReturn> map, params string[] splitColumns)
        {
            _map = map;
            _splitColumns = string.Join(",", splitColumns);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithMap<TFirst, TSecond, TThird, TFourth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TReturn> map, params string[] splitColumns)
        {
            _map = map;
            _splitColumns = string.Join(",", splitColumns);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithMap<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, params string[] splitColumns)
        {
            _map = map;
            _splitColumns = string.Join(",", splitColumns);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithMap<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, params string[] splitColumns)
        {
            _map = map;
            _splitColumns = string.Join(",", splitColumns);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithMap<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, params string[] splitColumns)
        {
            _map = map;
            _splitColumns = string.Join(",", splitColumns);
            return this;
        }

        public SprocRepositoryOptions<T> Build()
        {
            var result = new SprocRepositoryOptions<T>(_sprocs, _map);
            return result;
        }
    }

    public class SprocInfoBuilder<T>
    {
        private readonly SprocInfo<T> _sproc;

        public SprocInfoBuilder(string sprocName)
        {
            _sproc = new SprocInfo<T>(sprocName);
        }

        public SprocInfoBuilder<T> WithIdParam(string idParamName)
        {
           _sproc.Parameters.Add(idParamName, SprocConstants.ID_PLACE_HOLDER);
            return this;
        }

        public SprocInfoBuilder<T> WithParameter(string paramName, object value)
        {
            _sproc.Parameters.Add(paramName, value);
            return this;
        }

        public SprocInfoBuilder<T> WithParameter(string paramName, Expression<Func<T, object>> propExpression)
        {
            _sproc.ParamToPropMap.Add(paramName, propExpression);
            return this;
        }

        internal SprocInfo<T> Build()
        {
            return _sproc;
        }
    }
}
