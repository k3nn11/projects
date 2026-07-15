using FoRavers.Helpers.DTOs;
using FoRavers.Models;

namespace FoRavers.Helpers
{
    public interface IFollowTargetResolver
    {
        Task<FollowTargetSummary?> TargetResolverAsync(Follow follow);
    }
}
