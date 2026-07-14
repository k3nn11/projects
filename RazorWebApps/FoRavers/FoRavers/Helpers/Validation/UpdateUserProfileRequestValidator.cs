using FoRavers.Helpers.DTOs;
using FluentValidation;

namespace FoRavers.Helpers.Validation
{
    public class UpdateUserProfileRequestValidator : AbstractValidator<UpdateUserProfileDTO>
    {
        public UpdateUserProfileRequestValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
                .MaximumLength(30)
                .When(x => x.UserName is not null);

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => x.Email is not null);

            RuleFor(x => x.ProfilePhoto)
                .Must(BeAValidUrl).WithMessage("Profile photo must be a valid URL.")
                .When(x => x.ProfilePhoto is not null);

            RuleFor(x => x.MusicGenre)
                .MaximumLength(50)
                .When(x => x.MusicGenre is not null);

            
            RuleFor(x => x)
                .Must(x => x.UserName is not null || x.Email is not null
                        || x.ProfilePhoto is not null || x.MusicGenre is not null)
                .WithMessage("At least one field must be provided.");
        }

        private bool BeAValidUrl(string? url) =>
            Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
