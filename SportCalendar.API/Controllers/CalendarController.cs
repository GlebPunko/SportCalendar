using Microsoft.AspNetCore.Mvc;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Models.Calendar;

namespace SportCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("get-day-act")]
        public async Task GetDayActivities([FromQuery] string date, CancellationToken cancellationToken)
        {
            HttpContext.Items["data"] = await _calendarService.GetDayActivities(date, cancellationToken);
        }

        [HttpPost("create-act-day")]
        public async Task CreateActivitiesInDay([FromBody] CreateCalendarActivityModel activity)
        {
            HttpContext.Items["data"] = await _calendarService.AddActivitiesInDay(activity);
        }

        [HttpPost("upt-done")]
        public async Task UpdateIsDone([FromBody] UpdateActivityDoneModel model)
        {
            HttpContext.Items["data"] = await _calendarService.ChangeIsDone(model);
        }
    }
}
