using VillaApi.Models;

namespace VillaApi.Core.Contracts
{
    public interface IVillaRepository:IRepository<VillaM>
    {
        Task Update(VillaM villaM);
    }
}
