using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Services
{
    public class PromoterService
    {
        private readonly IRepository<Promoter> _promoterRepository;
        private readonly IRepository<Event> _eventRepository;
        
        public PromoterService(IRepository<Promoter> promoterRepository, IRepository<Event> eventRepository)
        {
            _promoterRepository = promoterRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Event> OrganizeEventAsync(Guid promoterID, string eventName, DateTime eventDate, string ticketLink, string lineup, Venue venue)
        {
            var promoter = await _promoterRepository.GetByIdAsync(promoterID);
            if (promoter is null)
            {
                throw new InvalidOperationException($"Promoter with ID {promoterID} not found.");
            }
            var newEvent = new Event
            {
                EventName = eventName,
                Date = eventDate,
                TicketLink = ticketLink,
                Lineup = lineup,
                Venue = venue,
                Promoter = promoter
            };
            await _eventRepository.AddAsync(newEvent);
            return newEvent;
        }
    }
}
