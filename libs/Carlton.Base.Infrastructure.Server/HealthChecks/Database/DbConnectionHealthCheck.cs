using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Carlton.Base.Infrastructure.Server.HealthChecks.Database
{
    public abstract class DbConnectionHealthCheck : IHealthCheck
    {
        public string Name { get; }

        protected DbConnectionHealthCheck(string name, string connectionString)
            : this(name, connectionString, testQuery: null)
        {
        }

        protected DbConnectionHealthCheck(string name, string connectionString, string testQuery)
        { 
            Name = name;
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            TestQuery = testQuery;
        }


        protected string ConnectionString { get; }

        // This sample supports specifying a query to run as a boolean test of whether the database
        // is responding. It is important to choose a query that will return quickly or you risk
        // overloading the database.
        //
        // In most cases this is not necessary, but if you find it necessary, choose a simple query such as 'SELECT 1'.
        protected string TestQuery { get; }

        protected abstract DbConnection CreateConnection(string connectionString);

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var connection = CreateConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

                    if (TestQuery != null)
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = TestQuery;

                        await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
                catch (DbException ex)
                {
                    return HealthCheckResult.Unhealthy(exception: ex);
                }
            }

            return HealthCheckResult.Healthy();
        }
    }
}

