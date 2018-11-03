using System.Data;

namespace Carlton.Infrastructure.Data.Connections
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
