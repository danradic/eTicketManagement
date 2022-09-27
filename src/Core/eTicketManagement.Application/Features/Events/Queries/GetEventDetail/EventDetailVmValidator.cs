using FluentValidation;

namespace eTicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class EventDetailVmValidator : AbstractValidator<EventDetailVm>
    {
        public EventDetailVmValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
