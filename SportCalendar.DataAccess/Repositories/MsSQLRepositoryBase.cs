using SportCalendar.Database;

namespace SportCalendar.DataAccess.Repositories
{
    public abstract class MsSqlRepositoryBase(string connectionString)
    {
        protected IDb Database { get; } = new MsSql(connectionString);
    }
}
