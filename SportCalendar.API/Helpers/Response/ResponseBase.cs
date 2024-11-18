using SportCalendar.Domain.Enums;
using System.Text.Json.Serialization;

namespace SportCalendar.API.Helpers.Response
{
    public class ResponseBase
    {
        public ResponseBase(bool success, ResponseStatus status, object data)
        {
            Success = success;
            Status = status;
            Data = data;
        }

        public bool Success { get; protected set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ResponseStatus Status { get; protected set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Data { get; protected set; }
    }
}
