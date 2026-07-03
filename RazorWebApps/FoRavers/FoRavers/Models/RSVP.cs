namespace FoRavers.Models
{
    public class RSVP : EntityBase
    {
        public  Guid UserId { get; set; }

        public Guid EventId { get; set; }

        public RSVPStatus Status { get; set; } 

        public User User { get; set; } = null!;

        public Event Event { get; set; } = null!;
    }
}
