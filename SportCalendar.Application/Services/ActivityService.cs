using AutoMapper;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Models.Activity;
using SportCalendar.Application.Validators.Activity;
using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Domain.CustomExceptions;
using SportCalendar.Domain.CustomExceptions.Activity;
using SportCalendar.Entity;

namespace SportCalendar.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activateRepository;
        private readonly CreateActivityValidator _createValidator;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper, CreateActivityValidator createValidator)
        {
            _activateRepository = activityRepository;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivities(CancellationToken cancellationToken)
        {
            var result = await _activateRepository.GetActivities(cancellationToken);

            if(!result.Any())
                Console.WriteLine("Result is null!");

            return _mapper.Map<IEnumerable<ActivityModel>>(result);
        }
            
        public async Task<bool> AddActivity(CreateActivityModel activity)
        {
            var result = await _createValidator.ValidateAsync(activity);

            if (!result.IsValid)
                throw new RequestIsNotValidException();

            var isSuccess = await _activateRepository.AddActivity(_mapper.Map<ActivityEntity>(activity));

            if (!isSuccess)
                throw new ActivityIsNotAddedException();

            return isSuccess;
        }
    }
}
