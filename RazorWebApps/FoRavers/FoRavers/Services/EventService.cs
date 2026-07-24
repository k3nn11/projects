using FoRavers.Data;
using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Services
{
    public class EventService
    {
        private readonly IRepository<Event> _events;

        private readonly IRepository<Promoter> _promoters;

        public EventService(IRepository<Event> events, IRepository<Promoter> promoters)
        {
            _events = events;
            _promoters = promoters;
        }

        public async Task<Event> OrganizeEventAsync(Guid promoterID, string eventName, DateTime eventDate, string ticketLink, string lineup, Venue venue)
        {
            var promoter = await _promoters.GetByIdAsync(promoterID);
            if (promoter is null)
            {
                throw new InvalidOperationException($"Promoter with ID {promoterID} not found.");
            }

            var evt = Event.CreatePromoterEvent(eventName, eventDate, lineup, ticketLink);
            evt.SetVenue(venue);
            await _events.AddAsync(evt);
            return evt;
        }

        public async Task<Event> HostEventAsync(Guid venueID, string eventName, DateTime eventDate, string ticketLink, string lineup)
        {
            var venue = await _events.GetByIdAsync(venueID);
            if(venue is null)
            {
                throw new InvalidOperationException($"Venue with ID {venueID} not found.");
            }

            var evt = Event.CreateVenueEvent(eventName, eventDate, lineup, ticketLink);
            await _events.AddAsync(evt);
            return evt;
        }
    }
}
