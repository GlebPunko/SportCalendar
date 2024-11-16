using AutoMapper;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Models.Calendar;
using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Entity;

namespace SportCalendar.Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;

        public CalendarService(ICalendarRepository calendarRepository, IMapper mapper)
        {
            _calendarRepository = calendarRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DayActivitiesModel>> GetDayActivities(DateOnly date, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<DayActivitiesModel>>(
                await _calendarRepository.GetDayActivities(date, cancellationToken));
        }

        public async Task AddActivitiesInDay(CreateCalendarActivityModel activity)
        {
            if (activity.Activity is null ||
                activity.Date == default ||
                activity.Activity.ActivityId == default)
                throw new Exception("Bad model!"); // TODO will be validate

            var isSuccess = await _calendarRepository.AddActivities(
                _mapper.Map<AddCalendarActivity>(activity));

            if (!isSuccess)
                throw new Exception("Model is not created."); // TODO Will prepare exMiddleware
        }

        public async Task<bool> ChangeIsDone(UpdateActivityDoneModel model)
        {
            if (model.CalendarId == default || model.ActivityId == default)
                throw new Exception("Bad model!"); // TODO Will validate

            var isSuccess = await _calendarRepository.ChangeIsDone(model.IsDone, model.ActivityId, model.CalendarId);

            if (!isSuccess)
                throw new Exception("Not changed!");

            return model.IsDone;
        }
    }
}
