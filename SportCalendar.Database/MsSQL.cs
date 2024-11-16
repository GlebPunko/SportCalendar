using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SportCalendar.Database
{
    public class MsSql(string connectionString) : IDb
    {
        private string ConnectionString { get; set; } = connectionString;

        public async Task<IEnumerable<T>> LoadData<T>(string sql, object parameters, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            try
            {
                return await connection.QueryAsync<T>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
            catch (SqlException)
            {
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<T> LoadDataSingle<T>(string sql, object parameters, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            try
            {
                return await connection.QuerySingleOrDefaultAsync<T>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
            catch (SqlException)
            {
                return default;
            }
        }

        public async Task<TReturn> LoadDataMultipleSingle<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = (await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn)).SingleOrDefault();

            return result;
        }

        public async Task<TReturn> LoadDataMultipleSingle<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = (await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn)).SingleOrDefault();

            return result;
        }

        public async Task<TReturn> LoadDataMultipleSingle<T1, T2, T3, T4, TReturn>(string sql,
            Func<T1, T2, T3, T4, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = (await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn)).SingleOrDefault();

            return result;
        }

        public async Task<TReturn> LoadDataMultipleSingle<T1, T2, T3, T4, T5, TReturn>(string sql,
            Func<T1, T2, T3, T4, T5, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = (await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn)).SingleOrDefault();

            return result;
        }

        public async Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn);

            return result;
        }

        public async Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn);

            return result;
        }

        public async Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, T3, T4, TReturn>(string sql,
            Func<T1, T2, T3, T4, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn);

            return result;
        }

        public async Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, T3, T4, T5, TReturn>(string sql,
            Func<T1, T2, T3, T4, T5, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            IDbConnection connection = new SqlConnection(ConnectionString);

            var result = await connection.QueryAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken), dataBound, splitOn: splitOn);

            return result;
        }

        public async Task<bool> SaveData(string sql, object parameters = default)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            try
            {
                var rows = await connection.ExecuteAsync(sql, parameters);
                return rows > 0;
            }
            catch (SqlException)
            {
                return default;
            }
        }

        public Task<bool> SaveMultipleData<T>(IEnumerable<T> parameters, string tableName, CancellationToken cancellationToken = default)
            where T : class
        {
            throw new NotImplementedException();
        }
    }
}
