using SportCalendar.DataAccess.Interfaces;
using System.Diagnostics;

namespace SportCalendar.DataAccess.Repositories
{
    public class ActivityRepository(string connectionString) : MsSqlRepositoryBase(connectionString), IActivityRepository
    {
        public Task<bool> AddActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> GetActivities(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
