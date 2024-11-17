using FluentValidation;
using SportCalendar.Application.Models.Calendar;

namespace SportCalendar.Application.Validators.Calendar
{
    public class CreateCalendarActivityValidator : AbstractValidator<CreateCalendarActivityModel>
    {
        public CreateCalendarActivityValidator()
        {
            RuleFor(x => x.Activity).NotNull().NotEmpty();
            RuleFor(x => x.Activity.CalendarId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Activity.UnitCount).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Activity.Done).NotNull().NotEmpty();
        }
    }
}
