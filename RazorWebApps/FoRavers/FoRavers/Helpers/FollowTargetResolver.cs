using FoRavers.Helpers.DTOs;
using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Helpers
{
    public class FollowTargetResolver : IFollowTargetResolver
    {
        private readonly IRepository<Promoter> _promoters;
        private readonly IRepository<Event> _events;

        public FollowTargetResolver(IRepository<Promoter> promoters, IRepository<Event> events) 
        {
            _events = events;
            _promoters = promoters;
        }
        public async Task<FollowTargetSummary?> TargetResolverAsync(Follow follow)
        {
           if(follow == null) throw new ArgumentNullException("The follow object is null");

           if(follow.IsPromoterTarget())
            {
                var promoter = await _promoters.GetByIdAsync(follow.TargetId);

                return promoter is null ? null : new FollowTargetSummary
                {
                    Type = "Promoter",
                    Id = promoter.Id.ToString(),
                    Name = promoter.Name
                };
           }

           if(follow.IsVenueTarget())
            {
                var eventEntity = await _events.GetByIdAsync(follow.TargetId);
                return eventEntity is null ? null : new FollowTargetSummary
                {
                    Type = "Event",
                    Id = eventEntity.Id.ToString(),
                    Name = eventEntity.EventName
                };
            }

            return null;
        }
    }
}
