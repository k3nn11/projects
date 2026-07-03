namespace FoRavers.Models
{
    public class Promoter : EntityBase
    {
        public  string Name { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();

        public ICollection<Follow> Follows { get; set; } = new List<Follow>();
    }
}
