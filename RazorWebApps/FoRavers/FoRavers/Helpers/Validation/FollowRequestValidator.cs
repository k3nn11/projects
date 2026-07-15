using FoRavers.Models;
using FoRavers.Helpers.DTOs;
using FluentValidation;

namespace FoRavers.Helpers.Validation
{
    public class FollowRequestValidator : AbstractValidator<FollowRequest>
    {
       public FollowRequestValidator()
        {
            RuleFor(x => x.TargetId).NotEmpty();
            RuleFor(x => x.Target).NotEmpty()
                .Must(t => Enum.TryParse<Target>(t, ignoreCase: true, out _))
                .WithMessage("Invalid target value. Must be either 'Promoter' or 'Venue'.");
        }
    }
}
