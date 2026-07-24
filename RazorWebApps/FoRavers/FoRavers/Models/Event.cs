using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FoRavers.Models
{
    public class Event : EntityBase
    {
        public string EventName { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Lineup{ get; set; } = string.Empty;

        public string TicketLink { get; set; } = string.Empty;

        public int GoingCount { get; set; }

        public Guid VenueId { get; set; }

        public Guid PromoterId { get; set; }

        public EventOwnerType OwnerType{  get; set; }

        public Venue Venue { get; set; } = null!;

        public Promoter Promoter { get; set; } = null!;

        public ICollection<RSVP> RSVPs { get; set; } = new List<RSVP>();

        private Event() { }

        private Event(string eventName, DateTime date, string lineup, string ticketLink, EventOwnerType ownerType)
        {
            EventName = eventName;
            Date = date;
            Lineup = lineup;
            TicketLink = ticketLink;
            OwnerType = ownerType;
        }

        public static Event CreatePromoterEvent(string eventName, DateTime date, string lineup, string ticketLink)
        {
            return new Event(eventName, date, lineup, ticketLink, EventOwnerType.Promoter);
        }

        public static Event CreateVenueEvent(string eventName, DateTime date, string lineup, string ticketLink)
        {
            return new Event(eventName, date, lineup, ticketLink, EventOwnerType.Venue);
        }

        public void SetVenue(Venue venue)
            { Venue = venue; }

        public void IncrementCount() => GoingCount++;

        public void DecrementCount() => GoingCount = Math.Max(GoingCount - 1, 0);
    }
}
