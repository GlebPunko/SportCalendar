using SportCalendar.Application.Models.Activity;

namespace SportCalendar.Application.Interfaces
{
    public interface IActivityService
    {
        public Task<IEnumerable<ActivityModel>> GetActivities(CancellationToken cancellationToken);
        public Task AddActivity(CreateActivityModel activity);
    }
}
