using FluentValidation;
using Pebolim.Domain.Entities;

namespace Pebolim.Service.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(t => t.TeamName)
                .NotEmpty().WithMessage("Please fill in a team name.")
                .NotNull().WithMessage("Please fill in a team name.");

            RuleFor(t => t.PrimaryColour)
                .NotEmpty().WithMessage("Team must have a primary colour.")
                .NotNull().WithMessage("Team must have a primary colour.");

            RuleFor(t => t.SecondaryColour)
                .NotEmpty().WithMessage("Team must have a secondary colour.")
                .NotNull().WithMessage("Team must have a secondary colour.");

            RuleFor(t => t.Base64Flag)
                .NotEmpty().WithMessage("Team must have a flag.")
                .NotNull().WithMessage("Team must have a flag.");
        }
    }
}
