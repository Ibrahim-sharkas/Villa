using VillaApi.Models.DTO;

namespace VillaApi.Data
{
    public  static class VillaStore
    {
        public static List< VillaDTO > VillaDTOs= new List<VillaDTO>
            {
                new VillaDTO{ID=1, Name="Pool",Occupency=3,Sqft=200 },
            new VillaDTO{ID=2, Name="Garden",Occupency=5,Sqft=250}
            };
    }
}
