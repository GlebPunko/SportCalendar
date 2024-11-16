namespace SportCalendar.Database
{
    public interface IDb
    {
        Task<IEnumerable<T>> LoadData<T>(string sql, object parameters = null, CancellationToken cancellationToken = default);
        Task<T> LoadDataSingle<T>(string sql, object parameters = null, CancellationToken cancellationToken = default);
        Task<TReturn> LoadDataMultipleSingle<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<TReturn> LoadDataMultipleSingle<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<TReturn> LoadDataMultipleSingle<T1, T2, T3, T4, TReturn>(string sql,
            Func<T1, T2, T3, T4, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<TReturn> LoadDataMultipleSingle<T1, T2, T3, T4, T5, TReturn>(string sql,
            Func<T1, T2, T3, T4, T5, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, T3, T4, TReturn>(string sql,
            Func<T1, T2, T3, T4, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<IEnumerable<TReturn>> LoadDataMultiple<T1, T2, T3, T4, T5, TReturn>(string sql,
            Func<T1, T2, T3, T4, T5, TReturn> dataBound, object param = null, string splitOn = "Id", CancellationToken cancellationToken = default);
        Task<bool> SaveData(string sql, object parameters = null);
        Task<bool> SaveMultipleData<T>(IEnumerable<T> parameters, string tableName, CancellationToken cancellationToken = default) where T : class;
    }
}
