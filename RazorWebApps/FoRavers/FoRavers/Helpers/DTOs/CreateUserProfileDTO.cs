namespace FoRavers.Helpers.DTOs
{
    public class CreateUserProfileDTO
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ProfilePhoto { get; set; } = null!;

        public string? MusicGenre { get; set; }
    }
}
