using FluentValidation;
using Pebolim.Domain.Entities;

namespace Pebolim.Service.Validators
{
    public class ProfileValidator : AbstractValidator<UserProfile>
    {
        public ProfileValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Please fill in a profile name.")
                .NotNull().WithMessage("Please fill in a profile name.");

            RuleFor(p => p.User)
                .NotNull().WithMessage("UserProfile must reference an user.");
        }
    }
}
