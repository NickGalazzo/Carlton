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
        public BaseDapperSprocRepository(IDbConnectionFactory factory, IEnumerable<SprocInfo<T>> sprocs) 
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
                var p = CreateDynamicParameters(sproc, entity);
                await cn.QueryAsync<T>(sproc.SprocName, p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

