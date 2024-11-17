using SportCalendar.Application.Models.Calendar;

namespace SportCalendar.Application.Interfaces
{
    public interface ICalendarService
    {
        public Task<IEnumerable<DayActivitiesModel>> GetDayActivities(DateOnly date, CancellationToken cancellationToken);
        public Task<bool> ChangeIsDone(UpdateActivityDoneModel model);
        public Task<bool> AddActivitiesInDay(CreateCalendarActivityModel activity);
    }
}
