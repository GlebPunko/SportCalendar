using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions.Calendar
{
    public class ActivityDoneIsNotUpdatedException : ResponseBaseException
    {
        public ActivityDoneIsNotUpdatedException() : base(ResponseStatus.Error_ActivityDoneIsNotUpdated)
        {
            
        }
    }
}
