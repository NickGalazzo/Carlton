//using Npgsql;
//using System.Data.Common;

//namespace Carlton.Infrastructure.HealthChecks.Database
//{
//    public class PostgresConnectionHealthCheck : DbConnectionHealthCheck
//    {
//        private static readonly string DefaultTestQuery = "Select 1";

//        public PostgresConnectionHealthCheck(string name, string connectionString)
//            : this(name, connectionString, testQuery: DefaultTestQuery)
//        {
//        }

//        public PostgresConnectionHealthCheck(string name, string connectionString, string testQuery)
//            : base(name, connectionString, testQuery ?? DefaultTestQuery)
//        {
//        }

//        protected override DbConnection CreateConnection(string connectionString)
//        {
//            return new NpgsqlConnection(connectionString);
//        }
//    }
//}