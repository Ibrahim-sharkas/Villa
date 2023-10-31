using VillaUtility;
using VillaWeb.Models;
using VillaWeb.Models.DTO;
using VillaWeb.Services.IServices;

namespace VillaWeb.Services
{
    public class VillaNumberService : BaseService, IVillaNumberServices
    {
        private readonly IHttpClientFactory clientFactory;
        private string url;
        public VillaNumberService(IHttpClientFactory httpClientFactory,IConfiguration configuration) : base(httpClientFactory)
        {
            clientFactory=httpClientFactory;
            url = configuration.GetValue<string>("ServicesUrl:VillaApi");
        }

        public Task<T> CreateVillaNum<T>(VillaNumberCreatDto model)
        {
            return SendAsync<T>(new ApiRequest
            {
               ApiType=SD.ApiType.POST,
               Data = model,ApiUrl=url+ "/api/VillaNumber"
            });
        }

        public Task<T> DeleteVillaNum<T>(int id)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType=SD.ApiType.DELETE,
                ApiUrl = url + "/api/VillaNumber/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType=SD.ApiType.GET,
                ApiUrl = url + "/api/VillaNumber"
            });
        }

        public Task<T> GetTAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType=SD.ApiType.GET,
                ApiUrl = url + "/api/VillaNumber/" + id
            });
        }

        public Task<T> UpdateVillaNum<T>(VillaNumberUpdateDto model)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType=SD.ApiType.PUT,
                ApiUrl = url + "/api/VillaNumber/" + model.VillaNO
                ,Data = model   
            });
        }
    }
}
