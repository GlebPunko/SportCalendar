using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions.Activity
{
    public class ActivityIsNotAddedException : ResponseBaseException
    {
        public ActivityIsNotAddedException() : base(ResponseStatus.Error_ActivityIsNotAdded)
        {

        }
    }
}
