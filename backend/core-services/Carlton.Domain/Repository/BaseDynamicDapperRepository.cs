using Carlton.Domain.BusinessObjects;
using Carlton.Infrastructure.Data.Repository.Base;
using Carlton.Infrastructure.Data.Repository.Dapper.Dynamic;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository
{
    public class BaseDynamicDapperRepository<T, IdType> : IRepository<T, IdType>
        where T : EntityBase<IdType>
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        protected IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }

        public BaseDynamicDapperRepository(string connectionSting, string tableName)
        {
            _connectionString = connectionSting;
            _tableName = tableName;
        }

        protected virtual dynamic Mapping(T item)
        {
            return item;
        }

        public async virtual Task Insert(T item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                await cn.InsertAsync<IdType>(_tableName, parameters);
            }
        }

        public async virtual Task Update(T item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                await cn.UpdateAsync(_tableName, parameters);
            }
        }

        public async virtual Task Delete(T item)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                await cn.ExecuteAsync($"DELETE FROM {_tableName} WHERE {nameof(T)}Id={ item.Id }");
            }
        }

        public async virtual Task<T> FindById(IdType id)
        {
            T item = default(T);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                item = (await cn.QueryAsync<T>($"SELECT * FROM  {_tableName} WHERE {nameof(T)}Id={id}")).SingleOrDefault();
            }

            return item;
        }

        public async virtual Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> items = null;

            // extract the dynamic sql query and parameters from predicate
            QueryResult result = DynamicQuery.GetDynamicQuery(_tableName, predicate);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = await cn.QueryAsync<T>(result.Sql, (object)result.Param);
            }

            return items;
        }

        public async virtual Task<IEnumerable<T>> FindAll()
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = await cn.QueryAsync<T>("SELECT * FROM " + _tableName);
            }

            return items;
        }
    }
}
