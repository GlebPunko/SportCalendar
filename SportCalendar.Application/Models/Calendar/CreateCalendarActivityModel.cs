using SportCalendar.Entity;

namespace SportCalendar.Application.Models.Calendar
{
    public class CreateCalendarActivityModel
    {
        public CalendarActivity Activity { get; set; }
        public DateOnly Date { get; set; }
    }
}
