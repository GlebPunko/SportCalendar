using SportCalendar.API.Helpers.Response;
using SportCalendar.API.Helpers;
using SportCalendar.Domain.CustomExceptions;
using SportCalendar.Domain.Enums;
using System.Net;
using SportCalendar.API.Attributes;

namespace SportCalendar.API.Middlaware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, RequestContext requestContext)
        {
            try
            {
                await _next(context);

                var hasNoReturns = requestContext.Endpoint?.Metadata.GetMetadata<NoReturnItemsAttribute>() is not null;

                if (!hasNoReturns && requestContext?.Endpoint?.Metadata.Any() == true)
                {
                    if (!context.Response.HasStarted)
                    {
                        var data = context.Items["data"];

                        var response = new ResponseSuccess(data);

                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        await context.Response.WriteAsJsonAsync(response);
                    }
                }
            }
            catch (ResponseBaseException ex)
            {
                var data = ex.ErrorData ?? context.Items["data"];

                object error = null;
#if DEBUG
                error = $"Error: {ex.Message}\n\n{ex.StackTrace}";
#endif

                var response = new ResponseError(ex.ResponseStatus, data, error);

                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                object error = null;

#if DEBUG
                error = $"Error: {ex.Message}\n\n{ex.StackTrace}";
#endif
                //TODO Logger for log ex

                var response = new ResponseError(ResponseStatus.Error_Unknown, null, error);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
