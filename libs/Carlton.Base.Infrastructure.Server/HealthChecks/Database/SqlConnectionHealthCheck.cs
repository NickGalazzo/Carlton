using System.Data.Common;
using System.Data.SqlClient;

namespace Carlton.Base.Infrastructure.Server.HealthChecks.Database
{
    public class SqlConnectionHealthCheck : DbConnectionHealthCheck
    {
        private const string DefaultTestQuery = "Select 1";

        public SqlConnectionHealthCheck(string name, string connectionString)
            : this(name, connectionString, testQuery: DefaultTestQuery)
        {
        }

        public SqlConnectionHealthCheck(string name, string connectionString, string testQuery)
            : base(name, connectionString, testQuery ?? DefaultTestQuery)
        {
        }

        protected override DbConnection CreateConnection(string connectionString)
        {
            return null; // new SqlConnection(connectionString);
        }
    }
}

