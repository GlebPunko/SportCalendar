using AutoMapper;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Models.Activity;
using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Entity;

namespace SportCalendar.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activateRepository;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activateRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityModel>> GetActivities(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ActivityModel>>(await _activateRepository.GetActivities(cancellationToken));
        }
            
        public async Task AddActivity(CreateActivityModel activity)
        {
            if (string.IsNullOrEmpty(activity.ActivityName) || activity.ActivityUnitId <= 0)
                throw new Exception("model is bad."); // TODO Will be validate

            var isSuccess = await _activateRepository.AddActivity(_mapper.Map<Activity>(activity));

            if (!isSuccess)
                throw new Exception("Activity is not added!");// TODO Will be prepare in exMiddleware
        }
    }
}
