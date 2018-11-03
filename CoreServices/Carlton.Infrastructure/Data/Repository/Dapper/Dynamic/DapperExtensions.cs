using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Dynamic
{
    public static class DapperExtensions
    {
        public async static Task<IdType> InsertAsync<IdType>(this IDbConnection cnn, string tableName, dynamic param)
        {
            var result = await SqlMapper.QueryAsync<IdType>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result;
        }

        public async static Task UpdateAsync(this IDbConnection cnn, string tableName, dynamic param)
        {
            await SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }
    }
}
