using FoRavers.Data;
using FoRavers.Models;
using Microsoft.EntityFrameworkCore;

namespace FoRavers.Repositories
{
    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        public FollowRepository(FoRaversDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(Guid userId, Guid targetId, string targetType)
        {
            var parsedTarget = Enum.TryParse<Target>(targetType, ignoreCase: true, out var target);
            return parsedTarget && await _context.Follows.AnyAsync(f => f.UserId == userId && f.TargetId == targetId && f.Target == target);
        }
    }
}
