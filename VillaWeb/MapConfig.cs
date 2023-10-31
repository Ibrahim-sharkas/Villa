using AutoMapper;
using VillaWeb.Models.DTO;

namespace VillaWeb
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            //CreateMap<VillaDto, VillaCreatDto>().ReverseMap();
            //CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaMDTO,VillaMCreateDTO>().ReverseMap();
            CreateMap<VillaMDTO,VillaMUpdateDTO>().ReverseMap();    

            CreateMap<VillaNumberDto,VillaNumberCreatDto>().ReverseMap();   
            CreateMap<VillaNumberDto,VillaNumberUpdateDto>().ReverseMap();  
        }
    }
}
