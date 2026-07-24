namespace FoRavers.Models
{
    public class RSVP : EntityBase
    {
        public  Guid UserId { get; set; }

        public Guid EventId { get; set; }

        public RSVPStatus Status { get; set; } 

        public User User { get; set; } = null!;

        public Event Event { get; set; } = null!;

        public RSVP() { }

        public RSVP(Guid userId, Guid eventId)
        {
            UserId = userId;
            EventId = eventId;
            Status = RSVPStatus.Interested;
        }

        private void SetStatus(RSVPStatus status)
        {
            if (!Enum.IsDefined(typeof(RSVPStatus), status))
            {
                throw new ArgumentException($"Invalid RSVP status: {status}");
            }
            Status = status;
        }

        public void Confirm() => SetStatus(RSVPStatus.Confirmed);

        public void Cancel() => SetStatus(RSVPStatus.Canceled);

    }
}
