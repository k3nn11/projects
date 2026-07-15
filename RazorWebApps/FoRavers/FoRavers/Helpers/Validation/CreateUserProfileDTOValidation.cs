using FoRavers.Helpers.DTOs;
using FluentValidation;

namespace FoRavers.Helpers.Validation
{
    public class CreateUserProfileDTOValidation : AbstractValidator<CreateUserProfileDTO>
    {
        public CreateUserProfileDTOValidation() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required")
                .Matches(@"\A\S{3,15}\z").WithMessage("Username must be at least 3 characters long");
            RuleFor(x => x.ProfilePhoto).NotEmpty().WithMessage("Profile photo is required");
        }
    }
}
