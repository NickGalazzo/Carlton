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
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public abstract class BaseDapperReadonlySprocRepository<T, IdType> : IReadOnlySprocRepository<T, IdType>
    {
        private readonly IDbConnectionFactory _factory;
        protected Dictionary<string, SprocInfo<T>> Sprocs { get; }

        protected IDbConnection Connection
        {
            get
            {
                return _factory.Create();
            }
        }

        public BaseDapperReadonlySprocRepository(IDbConnectionFactory factory, IEnumerable<SprocInfo<T>> sprocs)
        {
            _factory = factory;
            Sprocs = sprocs.ToList().ToDictionary(o => o.SprocName, o => o);
        }

        public async Task<PagedResult<T>> Find(ISprocSpecification<T> specification)
        {
            return await Find(specification, null);
        }

        public async Task<PagedResult<T>> Find(ISprocSpecification<T> specification, IQueryConstraints<T> constraints)
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
            var sprocName = Sprocs[SprocConstants.FIND_ALL_SPROC];
            return await ExecuteStoredProcedure(sprocName, id);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            var sprocName = Sprocs[SprocConstants.FIND_ALL_SPROC];
            return await ExecuteStoredProcedure(sprocName);
        }

        private async Task<T> ExecuteStoredProcedure(SprocInfo<T> sproc, IdType id)
        {
            using (var cn = Connection)
            {
                var querySproc = sproc as SprocInfo<T>;
                var p = CreateDynamicParameters(sproc, id);

                var result = await cn.QueryAsync(sproc.SprocName, querySproc.SprocMapping.Types, querySproc.SprocMapping.MappingFunc, p,
                                       commandType: CommandType.StoredProcedure,
                                       splitOn: string.Join(",", querySproc.SprocMapping.SplitColumns));

                return result.FirstOrDefault();
            }
        }

        private async Task<IEnumerable<T>> ExecuteStoredProcedure(string sproc, object parameters)
        {
            using (var cn = Connection)
            {
                var p = new DynamicParameters(parameters);
                var results = await cn.QueryAsync<T>(sproc, p, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        private async Task<IEnumerable<T>> ExecuteStoredProcedure(SprocInfo<T> sproc)
        {
            using (var cn = Connection)
            {
                var querySproc = sproc as SprocInfo<T>;
                var results = await cn.QueryAsync(sproc.SprocName, sproc.SprocMapping.Types, sproc.SprocMapping.MappingFunc,
                                            commandType: CommandType.StoredProcedure,
                                            splitOn: string.Join(",", sproc.SprocMapping.SplitColumns));
                return results;
            }
        }

        private DynamicParameters CreateDynamicParameters(SprocInfo<T> sproc, IdType id)
        {
            var p = new DynamicParameters();
            var idParameter = sproc.Parameters.FirstOrDefault(o => (string)o.Value == SprocConstants.ID_PLACE_HOLDER);
            p.Add(idParameter.Key, id);
            return p;
        }

        protected DynamicParameters CreateDynamicParameters(SprocInfo<T> sproc, T entity)
        {
            if (sproc.AnyParameterProperties())
            {
                sproc.ConvertEntityPropertiesToParams(entity);
            }

            var p = new DynamicParameters();

            foreach (var param in sproc.Parameters)
            {
                p.Add(param.Key, param.Value);
            }

            return p;
        }

        private object GetPropertyValue(Expression<Func<T, object>> prop, T entity)
        {
            var propertyInfo = ((MemberExpression)prop.Body).Member as PropertyInfo;
            var value = propertyInfo.GetValue(entity);
            return value;
        }
    }
}
