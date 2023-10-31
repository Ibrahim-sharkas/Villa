using AutoMapper;
using VillaApi.Models;
using VillaApi.Models.DTO;

namespace VillaApi
{
    public class MapConfig:Profile
    {
        // creat ctor for class so it can be added to the controller through DI in program.cs
        public MapConfig()
        {
            CreateMap<VillaM, VillaDTO>();
            CreateMap<VillaDTO,VillaM>();

            CreateMap<VillaM,VillaCreateDto>().ReverseMap();
            CreateMap<VillaM,VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreatedDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberUpdatedDTO>().ReverseMap();
        }
    }
}
