using AutoMapper;
using FluentValidation;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Models.Calendar;
using SportCalendar.Application.Validators.Calendar;
using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Domain.CustomExceptions;
using SportCalendar.Domain.CustomExceptions.Calendar;
using SportCalendar.Entity.RelatedEntity;
using System.Diagnostics;

namespace SportCalendar.Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;
        private readonly CreateCalendarActivityValidator _createValidator;
        private readonly UpdateActivityDoneValidator _updateValidator;

        public CalendarService(ICalendarRepository calendarRepository, IMapper mapper, 
            UpdateActivityDoneValidator updateValidator, CreateCalendarActivityValidator createValidator)
        {
            _calendarRepository = calendarRepository;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<IEnumerable<DayActivitiesModel>> GetDayActivities(DateOnly date, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<DayActivitiesModel>>(
                await _calendarRepository.GetDayActivities(date, cancellationToken));
        }

        public async Task<bool> AddActivitiesInDay(CreateCalendarActivityModel activity)
        {
            var result = await _createValidator.ValidateAsync(activity);

            if (!result.IsValid)
                throw new RequestIsNotValidException();

            var isSuccess = await _calendarRepository.AddActivities(
                _mapper.Map<AddCalendarActivityRE>(activity));

            if (!isSuccess)
                throw new ActivitiesInDayNotAddedException();

            return isSuccess;
        }

        public async Task<bool> ChangeIsDone(UpdateActivityDoneModel model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
                throw new RequestIsNotValidException();

            var isSuccess = await _calendarRepository.ChangeIsDone(model.IsDone, model.ActivityId, model.CalendarId);

            if (!isSuccess)
                throw new ActivityDoneIsNotUpdatedException();

            return model.IsDone;
        }
    }
}
