using AutoMapper;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Models;

namespace KingsmanTailors.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Role, RoleForListDto>();
            CreateMap<Role, RoleForDetailedDto>();
        }
    }
}
