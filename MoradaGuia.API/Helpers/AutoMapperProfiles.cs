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
            CreateMap<Imovel, ImovelForListDto>()
                .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src =>
                    src.Fotos.FirstOrDefault(p => p.Principal).Url));
            CreateMap<Imovel, ImovelForDetailedDto>()
                .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src =>
                    src.Fotos.FirstOrDefault(p => p.Principal).Url));
            CreateMap<Imovel, ImovelFromUserDto>()
                .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src =>
                    src.Fotos.FirstOrDefault(p => p.Principal).Url));
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<ImovelForUpdateDto, Imovel>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
        }
    }
}