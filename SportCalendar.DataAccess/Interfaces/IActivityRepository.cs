using System.Diagnostics;

namespace SportCalendar.DataAccess.Interfaces
{
    public interface IActivityRepository
    {
        public Task<IEnumerable<Activity>> GetActivities(CancellationToken cancellationToken);
        public Task<bool> AddActivity(Activity activity);
    }
}
