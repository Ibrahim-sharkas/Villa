using VillaApi.Models;

namespace VillaApi.Core.Contracts
{
    public interface IVillaNumRepository:IRepository<VillaNumber>
    {

         Task Update(VillaNumber number);

    }
}
