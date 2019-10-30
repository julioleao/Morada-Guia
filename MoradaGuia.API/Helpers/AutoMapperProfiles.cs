using System.Linq;
using AutoMapper;
using MoradaGuia.API.Dtos;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src =>
                    src.Fotos.FirstOrDefault(p => p.Principal).Url));
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src =>
                    src.Fotos.FirstOrDefault(p => p.Principal).Url));
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}