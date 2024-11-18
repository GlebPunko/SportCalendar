using Microsoft.AspNetCore.Http.Features;
using SportCalendar.API.Helpers;

namespace SportCalendar.API.Middlaware
{
    public class ContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, RequestContext requestContext)
        {
            requestContext.Endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

            await _next(context);
        }
    }
}
