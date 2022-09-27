using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicketManagement.Application.Features.Register
{
    public class RegisterVmValidator : AbstractValidator<RegisterVm>
    {
        public RegisterVmValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email address is required.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
