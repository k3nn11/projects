using System.ComponentModel.DataAnnotations;

namespace FoRavers.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ProfilePhoto { get; set; } = string.Empty;

        public string MusicGenre { get; set; } = string.Empty;

        public ICollection<Follow> Follows { get; set; } = new List<Follow>();

        public ICollection<RSVP> RSVPs { get; set; } = new List<RSVP>();

        public void UpdateProfile(string userName, string email, string profilePhoto, string musicGenre)
        {
            if(UserName is not null)UserName = userName;
            if(Email is not null) Email = email;
            if(ProfilePhoto is not null) ProfilePhoto = profilePhoto;
            if(MusicGenre is not null) MusicGenre = musicGenre;
        }

    }
}
