using FluentValidation;
using SportCalendar.Application.Models.Activity;

namespace SportCalendar.Application.Validators.Activity
{
    public class CreateActivityValidator : AbstractValidator<CreateActivityModel>
    {
        public CreateActivityValidator()
        {
            RuleFor(x => x.ActivityUnitId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.ActivityName).NotEmpty().NotNull();  
        }
    }
}
