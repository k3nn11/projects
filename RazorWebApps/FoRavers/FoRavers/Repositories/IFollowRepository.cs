using FoRavers.Models;

namespace FoRavers.Repositories
{
    public interface IFollowRepository : IRepository<Follow>
    {
        Task<bool> ExistsAsync(Guid userId, Guid targetId, string targetType);
    }
}
