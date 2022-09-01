using FluentValidation;
using Pebolim.Domain.Entities;

namespace Pebolim.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Please fill in a username.")
                .NotNull().WithMessage("Please fill in a username.");

            RuleFor(u => u.PasswordHash)
                .NotEmpty().WithMessage("Please inform a valid password.")
                .NotNull().WithMessage("Please inform a valid password.");

            RuleFor(u => u.Salt)
                .NotEmpty().WithMessage("Error creating password salt.")
                .NotNull().WithMessage("Error creating password salt.");
        }
    }
}
