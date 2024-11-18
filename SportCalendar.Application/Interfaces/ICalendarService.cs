using SportCalendar.Application.Models.Calendar;

namespace SportCalendar.Application.Interfaces
{
    public interface ICalendarService
    {
        public Task<IEnumerable<DayActivitiesModel>> GetDayActivities(string dateString, CancellationToken cancellationToken);
        public Task<bool> ChangeIsDone(UpdateActivityDoneModel model);
        public Task<bool> AddActivitiesInDay(CreateCalendarActivityModel activity);
    }
}
