using SportCalendar.Entity.RelatedEntity;

namespace SportCalendar.DataAccess.Interfaces
{
    public interface ICalendarRepository
    {
        public Task<IEnumerable<DayActivitiesRE>> GetDayActivities(DateOnly date, CancellationToken cancellationToken);
        public Task<bool> ChangeIsDone(bool isDone, int activityId, int calendarId);
        public Task<bool> AddActivities(AddCalendarActivityRE activity);
    }
}
