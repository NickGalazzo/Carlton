using Carlton.Base.Infrastructure.Data.Connections;
using Carlton.Infrastructure.Data.Repository.Dapper;
using Dapper;
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
            var insert = Options.CrudSprocMap[SprocConstants.INSERT_SPROC];
            var p = new DynamicParameters(entity);
            await ExecuteStoredProcedure(insert, p);
        }

        public async Task Update(T entity)
        {
            var update = Options.CrudSprocMap[SprocConstants.UPDATE_SPROC];
            var p = new DynamicParameters(entity);
            await ExecuteStoredProcedure(update, p);
        }

        public async Task Delete(T entity)
        {
            var delete = Options.CrudSprocMap[SprocConstants.DELETE_SPROC];
            var p = new DynamicParameters(entity);
            await ExecuteStoredProcedure(delete, p);
        }
    }
}

