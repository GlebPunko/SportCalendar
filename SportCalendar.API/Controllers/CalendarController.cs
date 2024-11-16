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
        public async Task<IActionResult> GetDayActivities([FromQuery] DateOnly date, CancellationToken cancellationToken)
        {
            var result = await _calendarService.GetDayActivities(date, cancellationToken);

            return Ok(result);
        }

        [HttpPost("create-act-day")]
        public async Task<IActionResult> CreateActivitiesInDay([FromBody] CreateCalendarActivityModel activity)
        {
            await _calendarService.AddActivitiesInDay(activity);

            return Created();
        }

        [HttpPost("upt-done")]
        public async Task<IActionResult> UpdateIsDone([FromBody] UpdateActivityDoneModel model)
        {
            var result = await _calendarService.ChangeIsDone(model);

            return Ok(result);
        }
    }
}
