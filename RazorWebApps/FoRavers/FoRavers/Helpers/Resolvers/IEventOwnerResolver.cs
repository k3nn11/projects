using FoRavers.Helpers.DTOs;
using FoRavers.Models;

namespace FoRavers.Helpers.Resolvers
{
    public interface IEventOwnerResolver
    {
        Task<EventOwnerSummary?> ResolveAsync(Event evt);
    }
}

   
      