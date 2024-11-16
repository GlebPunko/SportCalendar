using SportCalendar.Entity;

namespace SportCalendar.DataAccess.Interfaces
{
    public interface IActivityRepository
    {
        public Task<IEnumerable<ActivityEntity>> GetActivities(CancellationToken cancellationToken);
        public Task<bool> AddActivity(ActivityEntity activity);
    }
}
