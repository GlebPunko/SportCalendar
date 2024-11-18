using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions.Calendar
{
    public class ActivitiesInDayNotAddedException : ResponseBaseException
    {
        public ActivitiesInDayNotAddedException() : base(ResponseStatus.Error_ActivitiesInDayNotAdded)
        {
            
            
        }
    }
}
