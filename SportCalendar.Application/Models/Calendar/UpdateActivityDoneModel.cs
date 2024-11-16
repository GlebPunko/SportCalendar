namespace SportCalendar.Application.Models.Calendar
{
    public class UpdateActivityDoneModel
    {
        public bool IsDone { get; set; }
        public int ActivityId { get; set; }
        public int CalendarId { get; set; }
    }
}
