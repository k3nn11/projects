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

    }
}
