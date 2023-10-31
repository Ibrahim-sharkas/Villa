using VillaWeb.Models.DTO;

namespace VillaWeb.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T>CreateAsync<T>(VillaMCreateDTO villaCreatDto);
        Task<T> UpdateAsync<T>(VillaMUpdateDTO villaUpdateDto);
        Task<T> DeleteAsync<T>(int id);
    }
}
