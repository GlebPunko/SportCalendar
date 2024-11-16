using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Entity;

namespace SportCalendar.DataAccess.Repositories
{
    public class CalendarRepository(string connectionString) : MsSqlRepositoryBase(connectionString), ICalendarRepository
    {
        public async Task<IEnumerable<DayActivities>> GetDayActivities(DateOnly date, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT c.Id as CalendarId, a.Id AS ActivityId, a.ActivityName, u.Unit, c.Date, ca.UnitCount " +
                "FROM calendar_activities ca " +
                "INNER JOIN activities a ON ca.ActivityId = a.Id " +
                "INNER JOIN calendars c ON ca.CalendarId = c.Id " +
                "INNER JOIN units u ON u.Id = a.ActivityUnitId " +
                "WHERE c.Date = @date";
            
            return await Database.LoadDataMultiple<Calendar, Activity, ActivityUnit, CalendarActivity, DayActivities>(sql, 
                (c, a, au, ca) =>
                    {
                        return new DayActivities
                        {
                            CalendarId = c.Id,
                            Date = c.Date,
                            ActivityId = a.Id,
                            ActivityName = a.ActivityName,
                            Unit = au.Unit,
                            UnitCount = ca.UnitCount
                        };
                    }, new { date }, "CalendarId, ActivityId, Unit, UnitCount", cancellationToken);
        }

        public async Task<bool> AddActivities(AddCalendarActivity activity)
        {
            var sql = "IF NOT EXISTS (SELECT 1 FROM calendars WHERE Date = @Date) " +
                "BEGIN " +
                "INSERT INTO calendars (Date, Done) VALUES (@Date, 0); " +
                "INSERT INTO calendar_activities (CalendarId, ActivityId, Done, UnitCount) " +
                "VALUES (SCOPE_IDENTITY(), @ActivityId, @Done, @UnitCount);" +
                "END;";

            return await Database.SaveData(sql, new { activity.Activity.CalendarId, activity.Activity.ActivityId, 
                activity.Activity.Done, activity.Activity.UnitCount, activity.Date});
        }

        public async Task<bool> ChangeIsDone(bool isDone, int activityId, int calendarId)
        {
            var sql = "UPDATE calendar_activities SET Done = @isDone " +
                "WHERE ActivityId = @activityId AND CalendarId = @calendarId;";

            return await Database.SaveData(sql, new { isDone, activityId, calendarId });
        }
    }
}
