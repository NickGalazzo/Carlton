using Carlton.Base.Infrastructure.Data.Connections;
using Carlton.Infrastructure.Data.Repository.Dapper;
using Dapper;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository
{
    public abstract class BaseDapperSprocRepository<T, TId> : BaseDapperReadonlySprocRepository<T, TId>
    {
        public BaseDapperSprocRepository(IDbConnectionFactory factory, SprocRepositoryOptions<T> options) 
            : base(factory, options)
        { 
        }

        public async Task Insert(T entity)
        {
            var insert = Options.CrudSprocMap[SprocConstants.INSERT_SPROC];
            var p = new DynamicParameters(entity);
            await ExecuteStoredProcedure(insert, p).ConfigureAwait(false);
        }

        public async Task Update(T entity)
        {
            var update = Options.CrudSprocMap[SprocConstants.UPDATE_SPROC];
            var p = new DynamicParameters(entity);
            await ExecuteStoredProcedure(update, p).ConfigureAwait(false);
        }

        public async Task Delete(T entity)
        {
            var delete = Options.CrudSprocMap[SprocConstants.DELETE_SPROC];
            var p = new DynamicParameters(entity);
            await ExecuteStoredProcedure(delete, p).ConfigureAwait(false);
        }
    }
}

