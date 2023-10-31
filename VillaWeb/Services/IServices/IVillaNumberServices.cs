using VillaWeb.Models.DTO;

namespace VillaWeb.Services.IServices
{
    public interface IVillaNumberServices
    {
       Task<T> GetTAsync<T>(int id);
        Task<T> GetAllAsync<T>();
        Task<T> CreateVillaNum<T>(VillaNumberCreatDto model);
        Task<T> UpdateVillaNum<T>(VillaNumberUpdateDto model);
        Task<T> DeleteVillaNum<T>(int id);
    }
}
