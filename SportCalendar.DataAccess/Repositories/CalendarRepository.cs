using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Entity;

namespace SportCalendar.DataAccess.Repositories
{
    public class CalendarRepository(string connectionString) : MsSqlRepositoryBase(connectionString), ICalendarRepository
    {
        public Task<bool> AddActivities(AddCalendarActivity activity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeIsDone(bool isDone)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DayActivities>> GetDayActivities(DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
