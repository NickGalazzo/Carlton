using Carlton.Infrastructure.Data.Connections;
using Carlton.Infrastructure.Data.Repository.Dapper;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository
{
    public abstract class BaseDapperSprocRepository<T, IdType> : BaseDapperReadonlySprocRepository<T, IdType>
    {
        public BaseDapperSprocRepository(IDbConnectionFactory factory, Dictionary<string, SprocInfo<T>> sprocs) 
            : base(factory, sprocs)
        { 
        }

        public async Task Insert(T entity)
        {
            var insert = Sprocs[SprocConstants.INSERT_SPROC];
            await ExecuteStoredProcedure(insert, entity);
        }

        public async Task Update(T entity)
        {
            var update = Sprocs[SprocConstants.UPDATE_SPROC];
            await ExecuteStoredProcedure(update, entity);
        }

        public async Task Delete(T entity)
        {
            var delete = Sprocs[SprocConstants.DELETE_SPROC];
            await ExecuteStoredProcedure(delete, entity);
        }

        private async Task ExecuteStoredProcedure(SprocInfo<T> sproc, T entity)
        {
            using (var cn = Connection)
            {
                var p = GetParameters(sproc, entity);
                await cn.QueryAsync<T>(sproc.SprocName, p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

//var propertyInfo = ((MemberExpression)_sprocs.IdProperty.Body).Member as PropertyInfo;
//var id = propertyInfo.GetValue(entity);

//var p = new DynamicParameters();
//p.Add($"@{nameof(entity)}", id);
//                p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
//                p.Add("@c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

//                cn.Execute(_sprocs.DeleteSprocName, p, commandType: CommandType.StoredProcedure);

//                int b = p.Get<int>("@b");
//int c = p.Get<int>("@c");

//await cn.ExecuteAsync(_sprocs.DeleteSprocName, p, commandType: CommandType.StoredProcedure);