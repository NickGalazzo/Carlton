using Carlton.Infrastructure.Data.Base;
using Carlton.Infrastructure.Data.Connections;
using Carlton.Infrastructure.Data.Repository.Base;
using Carlton.Infrastructure.Data.Repository.Dapper.Contracts;
using Carlton.Infrastructure.Data.Repository.Dapper.Sproc.Contracts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public abstract class BaseDapperReadonlySprocRepository<T, IdType> : IReadOnlySprocRepository<T, IdType>
    {
        private static readonly Func<T, T> identityMap = o => o;
        private readonly IDbConnectionFactory _factory;
        protected SprocRepositoryOptions<T> Options { get; }

        protected IDbConnection Connection
        {
            get
            {
                return _factory.Create();
            }
        }

        public BaseDapperReadonlySprocRepository(IDbConnectionFactory factory, SprocRepositoryOptions<T> options)
        { 
            _factory = factory;
            Options = options;
        }

        public async Task<PagedResult<T>> Find<TSprocParams>(ISprocSpecification<T, TSprocParams> specification)
        {
            return await Find(specification, null);
        }

        public async Task<PagedResult<T>> Find<TSprocParams>(ISprocSpecification<T, TSprocParams> specification, IQueryConstraints<T> constraints)
        {
            var parameters = new DynamicParameters(specification.Params);

            if (constraints != null)
            {
                parameters.Add("@SortBy", constraints.SortPropertyName);
                parameters.Add("@SortOrder", constraints.SortOrder);
                parameters.Add("@PageNumber", constraints.PageNumber);
                parameters.Add("@PageSize", constraints.PageSize);
            }

            var results = await ExecuteStoredProcedure(specification.SprocName, parameters);
            return PagedResult<T>.Create(results, constraints.PageNumber);
        }

        public async Task<T> FindById(IdType id)
        {
            var sprocName = Options.CrudSprocMap[SprocConstants.FIND_BY_ID_SPROC];
            var parameters = new DynamicParameters(id);
            var result = await ExecuteStoredProcedure(sprocName, parameters);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            var sprocName = Options.CrudSprocMap[SprocConstants.FIND_ALL_SPROC];
            return await ExecuteStoredProcedure(sprocName);
        }

        private async Task<IEnumerable<T>> ExecuteStoredProcedure(string sprocName)
        {
            return await ExecuteStoredProcedure(sprocName, null);
        }

        protected async Task<IEnumerable<T>> ExecuteStoredProcedure(string sproc, DynamicParameters parameters)
        {
            if (Options.Map == null)
            {
                using (var cn = Connection)
                {
                    var results = await cn.QueryAsync<T>(sproc, parameters, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }
            else
            {
                return await ExecuteStoredProcedure(sproc, parameters, (dynamic)Options.Map);
            }
        }

        private async Task<IEnumerable<TReturn>> ExecuteStoredProcedure<TFirst, TSecond, TReturn>(string sproc, DynamicParameters parameters, Func<TFirst, TSecond, TReturn> map)
        {
            using (var cn = Connection)
            {
                var results = await cn.QueryAsync(sproc, map, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        private async Task<IEnumerable<TReturn>> ExecuteStoredProcedure<TFirst, TSecond, TThird, TReturn>(string sproc, DynamicParameters parameters, Func<TFirst, TSecond, TThird, TReturn> map)
        {
            using (var cn = Connection)
            {
                var results = await cn.QueryAsync(sproc, map, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        private async Task<IEnumerable<TReturn>> ExecuteStoredProcedure<TFirst, TSecond, TThird, TFourth, TReturn>(string sproc, DynamicParameters parameters, Func<TFirst, TSecond, TThird, TFourth, TReturn> map)
        {
            using (var cn = Connection)
            {
                var results = await cn.QueryAsync(sproc, map, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        private async Task<IEnumerable<TReturn>> ExecuteStoredProcedure<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sproc, DynamicParameters parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map)
        {
            using (var cn = Connection)
            {
                var results = await cn.QueryAsync(sproc, map, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        private async Task<IEnumerable<TReturn>> ExecuteStoredProcedure<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sproc, DynamicParameters parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map)
        {
            using (var cn = Connection)
            {
                var results = await cn.QueryAsync(sproc, map, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        private async Task<IEnumerable<TReturn>> ExecuteStoredProcedure<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sproc, DynamicParameters parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map)
        {
            using (var cn = Connection)
            {
                var results = await cn.QueryAsync(sproc, map, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
