using FluentValidation;

namespace eTicketManagement.Application.Features.Login
{
    public class LoginVmValidator : AbstractValidator<LoginVm>
    {
        public LoginVmValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email address is required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
