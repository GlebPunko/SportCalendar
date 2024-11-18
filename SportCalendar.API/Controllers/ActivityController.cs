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
        public async Task GetActivities(CancellationToken cancellationToken)
        {
            HttpContext.Items["data"] = await _activityService.GetActivities(cancellationToken);
        }

        [HttpPost("create-act")]
        public async Task CreateActivity([FromBody] CreateActivityModel model)
        {
            HttpContext.Items["data"] = await _activityService.AddActivity(model);
        }
    }
}
