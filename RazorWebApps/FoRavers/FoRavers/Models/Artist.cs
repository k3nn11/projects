using System.ComponentModel.DataAnnotations;

namespace FoRavers.Models
{
    public class Artist : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public  string Bio { get; set; } = string.Empty;

        public string ProfilePhoto { get; set; } = string.Empty;

        public string SocialMediaLinks { get; set; } = string.Empty;

        public string MusicLinks { get; set; } = string.Empty;
    }
}
