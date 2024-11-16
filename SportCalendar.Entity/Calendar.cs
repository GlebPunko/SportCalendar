namespace SportCalendar.Entity
{
    public class Calendar
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int UnitCount { get; set; }
        public bool Done { get; set; }
        public int ActivityId { get; set; }
    }
}
