using Carlton.Config.Data.Models.Config;
using Carlton.Infrastructure.Data.Connections;
using Carlton.Infrastructure.Data.Repository;
using Carlton.Infrastructure.Data.Repository.Dapper;

namespace Carlton.Config.Database.Repositories
{
    public class ResourceRepository : BaseDapperSprocRepository<Resource, int>
    {
        public ResourceRepository(IDbConnectionFactory factory, SprocRepositoryOptions<Resource> options) : base(factory, options)
        {
        }
    }
}
