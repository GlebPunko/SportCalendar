
using SportCalendar.Entity;

namespace SportCalendar.DataAccess.Interfaces
{
    public interface ICalendarRepository
    {
        public Task<IEnumerable<DayActivities>> GetDayActivities(DateOnly date);
        public Task<bool> ChangeIsDone(bool isDone);
        public Task<bool> AddActivities(AddCalendarActivity activity);
    }
}
