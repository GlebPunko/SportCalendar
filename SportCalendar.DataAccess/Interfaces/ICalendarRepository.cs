
using SportCalendar.Entity;

namespace SportCalendar.DataAccess.Interfaces
{
    public interface ICalendarRepository
    {
        public Task<IEnumerable<DayActivities>> GetDayActivities(DateOnly date, CancellationToken cancellationToken);
        public Task<bool> ChangeIsDone(bool isDone, int activityId, int calendarId);
        public Task<bool> AddActivities(AddCalendarActivity activity);
    }
}
