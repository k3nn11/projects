using FoRavers.Models;
using AutoMapper;

namespace FoRavers.Helpers.DTOs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
