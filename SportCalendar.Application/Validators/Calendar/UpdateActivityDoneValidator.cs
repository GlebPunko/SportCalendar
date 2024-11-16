using FluentValidation;
using SportCalendar.Application.Models.Calendar;

namespace SportCalendar.Application.Validators.Calendar
{
    public class UpdateActivityDoneValidator : AbstractValidator<UpdateActivityDoneModel>
    {
        public UpdateActivityDoneValidator()
        {
            RuleFor(x => x.ActivityId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.CalendarId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.IsDone).NotEmpty().NotNull();
        }
    }
}
