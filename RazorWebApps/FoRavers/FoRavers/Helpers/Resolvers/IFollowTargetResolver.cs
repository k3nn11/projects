using FoRavers.Helpers.DTOs;
using FoRavers.Models;

namespace FoRavers.Helpers.Resolvers
{
    public interface IFollowTargetResolver
    {
        Task<FollowTargetSummary?> TargetResolverAsync(Follow follow);
    }
}
