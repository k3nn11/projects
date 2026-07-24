using FoRavers.Helpers.DTOs;
using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Helpers.Resolvers
{
    public class EventOwnerResolver : IEventOwnerResolver
    {
        private readonly IRepository<Promoter> _promoters;

        private readonly IRepository<Venue> _venues;

        public EventOwnerResolver(IRepository<Promoter> promoters, IRepository<Venue> venues)
        {
            _promoters = promoters;
            _venues = venues;
        }

        public async Task<EventOwnerSummary?> ResolveAsync(Event evt)
        {
            if (evt.OwnerType == EventOwnerType.Promoter)
            {
                var promoter = await _promoters.GetByIdAsync(evt.Id);
                
                return promoter is null ? null : new EventOwnerSummary
                {
                    Id = promoter.Id,
                    Type = EventOwnerType.Promoter.ToString(),
                    Name = promoter.Name
                };

            }
            else if (evt.OwnerType == EventOwnerType.Venue)
            {
                var venue = await _venues.GetByIdAsync(evt.Id);
                return venue is null ? null : new EventOwnerSummary
                {
                    Id = venue.Id,
                    Type = EventOwnerType.Venue.ToString(),
                    Name = venue.Name
                };
            }
            else
            {
                throw new InvalidOperationException($"Unknown owner type for event with ID {evt.Id}.");
            }
        }
    }

}
