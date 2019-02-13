using AutoMapper;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;

namespace KingsmanTailors.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            // .ForMember(
            //     dest => dest.RoleCode,
            //     opt => opt.MapFrom(
            //         src => src.RoleCode));
            CreateMap<Role, RoleForListDto>();
            CreateMap<Role, RoleForDetailedDto>();
            CreateMap<Fabric, FabricForListDto>();
            CreateMap<OccasionFit, FitForListDto>();

            CreateMap<UserForEditDto, User>();

            // CreateMap<Fabric, FabricForDetailedDto>();
            // CreateMap<OccasionFit, FitForDetailedDto>();

            CreateMap<PhotoForCreateDto, SuitPhoto>()
            .ForMember(
                dest => dest.SuitId,
                opt => opt.MapFrom(
                    src => (int)src.InternalId
                )
            );
            CreateMap<SuitPhoto, PhotoForReturnDto>();

        }
    }
}
