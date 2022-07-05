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
        }
    }
}
