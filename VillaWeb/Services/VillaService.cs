using VillaUtility;
using VillaWeb.Models;
using VillaWeb.Models.DTO;
using VillaWeb.Services.IServices;

namespace VillaWeb.Services
{
    public class VillaService : BaseService, IVillaService
    {
        // declare private readonly httpclient to pass to baseService class to use it in syndasync request 
        private readonly IHttpClientFactory _ClientFactory;
        //declare url string and get url string from configration in appsetting json in the ctor
        private string _villaUrl;
        public VillaService(IHttpClientFactory httpClientFactory,IConfiguration configuration) : base(httpClientFactory)
        {
            _ClientFactory = httpClientFactory;
           _villaUrl= configuration.GetValue<string>("ServicesUrl:VillaApi");
        }

        public Task<T> CreateAsync<T>(VillaMCreateDTO villaCreatDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType=SD.ApiType.POST,
                Data = villaCreatDto,
                ApiUrl=_villaUrl+ "/api/VillaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,    
                ApiUrl=_villaUrl+ "/api/VillaAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = _villaUrl + "/api/VillaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType=SD.ApiType.GET,
                ApiUrl= _villaUrl + "/api/VillaAPI/"+id
            });
        }

        public Task<T> UpdateAsync<T>(VillaMUpdateDTO villaUpdateDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = villaUpdateDto,
                ApiUrl = _villaUrl + "/api/VillaAPI/" + villaUpdateDto.ID
            });
        }
    }
}
