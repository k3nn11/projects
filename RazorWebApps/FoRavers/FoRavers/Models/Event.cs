namespace FoRavers.Models
{
    public class Event : EntityBase
    {
        public string EventName { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Lineup{ get; set; } = string.Empty;

        public string TicketLink { get; set; } = string.Empty;

        public int GoingCount { get; set; }

        public Venue Venue { get; set; } = null!;

        public Promoter Promoter { get; set; } = null!;

        public ICollection<RSVP> RSVPs { get; set; } = new List<RSVP>();
    }
}
