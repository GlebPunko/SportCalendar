using Microsoft.AspNetCore.Mvc;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Models.Activity;

namespace SportCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("get-act")]
        public async Task<IActionResult> GetActivities(CancellationToken cancellationToken)
        {
            var result = await _activityService.GetActivities(cancellationToken);

            return Ok(result);
        }

        [HttpPost("create-act")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityModel model)
        {
            await _activityService.AddActivity(model);

            return Created();
        }
    }
}
