using System;
using System.Collections.Generic;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc
{
    public class SprocRepositoryOptionsBuilder<T>
    {
        private static readonly string FIND_BY_ID_SPROC = "{0}_GetById";
        private static readonly string FIND_ALL_SPROC = "{0}_GetAll";
        private static readonly string INSERT_SPROC = "{0}_Insert";
        private static readonly string UPDATE_SPROC = "{0}_Update";
        private static readonly string DELETE_SPROC = "{0}_Delete";

        private Delegate _map;
        private string _splitColumns;
        private readonly Dictionary<string, string> _crudSprocMap;
        private string _idParameter;

        public SprocRepositoryOptionsBuilder()
        {
            _crudSprocMap = new Dictionary<string, string>();
        }

        public SprocRepositoryOptionsBuilder<T> WithStandardCrudConventions()
        {
            var entityName = typeof(T).Name;

            var insert = string.Format(INSERT_SPROC, entityName);
            var update = string.Format(UPDATE_SPROC, entityName);
            var delete = string.Format(DELETE_SPROC, entityName);
            var findById = string.Format(FIND_BY_ID_SPROC, entityName);
            var findAll = string.Format(FIND_ALL_SPROC, entityName);
            var id = $"{entityName}Id";

            WithInsertSproc(insert);
            WithUpdateSproc(update);
            WithDeleteSproc(delete);
            WithFindByIdSproc(findById);
            WithFindAllSproc(findAll);
            WithIdParameter(id);

            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithInsertSproc(string name)
        {
            _crudSprocMap.Add(SprocConstants.INSERT_SPROC, name);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithUpdateSproc(string name)
        {
            _crudSprocMap.Add(SprocConstants.UPDATE_SPROC, name);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithDeleteSproc(string name)
        {
            _crudSprocMap.Add(SprocConstants.DELETE_SPROC, name);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithFindByIdSproc(string name)
        {
            _crudSprocMap.Add(SprocConstants.FIND_BY_ID_SPROC, name);
            return this;
        }

        public SprocRepositoryOptionsBuilder<T> WithFindAllSproc(string name)
        {
            _crudSprocMap.Add(SprocConstants.FIND_ALL_SPROC, name);
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

        public SprocRepositoryOptionsBuilder<T> WithIdParameter(string name)
        {
            _idParameter = name;
            return this;
        }

        public SprocRepositoryOptions<T> Build()
        {
            var result = new SprocRepositoryOptions<T>(_crudSprocMap, _idParameter, _map);
            return result;
        }
    }
}
