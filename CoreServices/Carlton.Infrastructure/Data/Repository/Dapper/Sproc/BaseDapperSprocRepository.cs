using Carlton.Infrastructure.Data.Connections;
using Carlton.Infrastructure.Data.Repository.Dapper;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository
{
    public abstract class BaseDapperSprocRepository<T, IdType> : BaseDapperReadonlySprocRepository<T, IdType>
    {
        public BaseDapperSprocRepository(IDbConnectionFactory factory, SprocRepositoryOptions<T> options) 
            : base(factory, options)
        { 
        }

        public async Task Insert(T entity)
        {
            var insert = Options.Sprocs[SprocConstants.INSERT_SPROC];
            await ExecuteStoredProcedure(insert, entity);
        }

        public async Task Update(T entity)
        {
            var update = Options.Sprocs[SprocConstants.UPDATE_SPROC];
            await ExecuteStoredProcedure(update, entity);
        }

        public async Task Delete(T entity)
        {
            var delete = Options.Sprocs[SprocConstants.DELETE_SPROC];
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

