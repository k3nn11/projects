using FoRavers.Models;
using FoRavers.Data;
using Microsoft.EntityFrameworkCore;

namespace FoRavers.Repositories
{
    public class RSVPRepository : Repository<RSVP>, IRSVPRepository
    {

        public RSVPRepository(FoRaversDbContext context) : base(context)
        {
        }

        public async Task<RSVP?> GetUserAndEventAsync(Guid userId, Guid eventId)
        {
            return await _context.RSVPs
                .Where(rsvp => rsvp.UserId == userId && rsvp.EventId == eventId)
                .FirstOrDefaultAsync();

        }
    }
}
