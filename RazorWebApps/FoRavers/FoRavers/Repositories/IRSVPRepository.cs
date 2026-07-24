using FoRavers.Models;

namespace FoRavers.Repositories
{
    public interface IRSVPRepository : IRepository<RSVP>
    {
        public Task<RSVP?> GetUserAndEventAsync(Guid userId, Guid eventId);
    }
}
