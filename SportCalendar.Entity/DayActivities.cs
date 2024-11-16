namespace SportCalendar.Entity
{
    public class DayActivities
    {
        public int CalendarId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Unit {  get; set; }
        public int UnitCount { get; set; }
        public DateOnly Date { get; set; }
    }
}
